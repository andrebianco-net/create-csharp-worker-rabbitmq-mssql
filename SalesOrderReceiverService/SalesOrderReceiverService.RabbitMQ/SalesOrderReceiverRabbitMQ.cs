using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SalesOrderReceiverService.RabbitMQ.Interfaces;
using RabbitMQ.Client.Events;
using System.Text;

namespace SalesOrderReceiverService.RabbitMQ
{
    public class SalesOrderReceiverRabbitMQ : ISalesOrderReceiverRabbitMQ
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SalesOrderReceiverRabbitMQ> _logger;

        public SalesOrderReceiverRabbitMQ(IConfiguration configuration,
                                          ILogger<SalesOrderReceiverRabbitMQ> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<List<string>> Receive()
        {
            
            List<string> messages = new List<string>();

            try
            {
                ManualResetEventSlim messagesRecievedGate = new ManualResetEventSlim(false);

                ConnectionFactory factory = new ConnectionFactory();
                factory.Uri = new Uri(_configuration["RabbitMQ:Uri"]);
                factory.ClientProvidedName = _configuration["RabbitMQ:ClientProvidedName"];

                IConnection connection = factory.CreateConnection();
                IModel channel = connection.CreateModel();

                string exchangeName = _configuration["RabbitMQ:ExchangeName"];
                string routingKey = _configuration["RabbitMQ:RoutingKey"];
                string queueName = _configuration["RabbitMQ:QueueName"];

                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queueName, false, false, false, null);
                channel.QueueBind(queueName, exchangeName, routingKey);

                uint prefetchSize = UInt32.Parse(_configuration["RabbitMQ:BasicQosPrefetchSize"]);
                ushort prefetchCount = ushort.Parse(_configuration["RabbitMQ:BasicQosPrefetchCount"]);
                bool global = Boolean.Parse(_configuration["RabbitMQ:BasicQosGlobal"]);

                channel.BasicQos(prefetchSize, prefetchCount, global);
                
                
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                

                consumer.Received += (sender, args) =>
                {

                    byte[] body = args.Body.ToArray();

                    string messageBody = Encoding.UTF8.GetString(body);

                    messages.Add(messageBody);

                    channel.BasicAck(args.DeliveryTag, false);

                };

                string consumerTag = channel.BasicConsume(queueName, false, consumer);

                channel.BasicCancel(consumerTag);

                channel.Close();
                connection.Close();

            }
            catch (System.Exception ex)
            {                
                _logger.LogError($"SalesOrderReceiverRabbitMQ -> Error: {ex.Message}");
            }   
            
            return messages;

        }
    }
}
