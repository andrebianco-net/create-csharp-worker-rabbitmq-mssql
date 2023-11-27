using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SalesOrderReceiverService.RabbitMQ.Interfaces;
using RabbitMQ.Client.Events;
using System.Text;
using SalesOrderReceiverService.Domain.Entities;
using Newtonsoft.Json;

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

        public async Task<List<Message>> Receive()
        {

            List<Message> messages = new List<Message>();

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


                consumer.Received += async (sender, args) =>
                {

                    try
                    {

                        byte[] body = args.Body.ToArray();

                        string messageBody = Encoding.UTF8.GetString(body);

                        Message message = convertDocToMessage(messageBody);

                        messages.Add(message);

                        channel.BasicAck(args.DeliveryTag, false);

                    }
                    catch (System.Exception ex)
                    {
                        _logger.LogError($"SalesOrderReceiverRabbitMQ.Receive.Received -> Error: {ex.Message}");
                    }

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

        private Message convertDocToMessage(string document)
        {
            Message message = null;

            try
            {

                SalesOrderDoc salesOrderFromJson = JsonConvert.DeserializeObject<SalesOrderDoc>(document);

                SalesOrder salesOrder = new SalesOrder(                    
                    salesOrderFromJson.Total, 
                    salesOrderFromJson.SoldAt, 
                    salesOrderFromJson.CustomerId, 
                    salesOrderFromJson.CategoryId, 
                    salesOrderFromJson.PaymentTypeId,
                    salesOrderFromJson.Id
                );

                List<SalesOrderItem> salesOrderItems = new List<SalesOrderItem>();
                SalesOrderItem salesOrderItem = null;

                foreach (int productId in salesOrderFromJson.ListProductId)
                {
                    salesOrderItem = new SalesOrderItem(
                        0,
                        productId 
                    );

                    salesOrderItems.Add(salesOrderItem);
                }

                message = new Message(salesOrder, salesOrderItems);

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"SalesOrderReceiverRabbitMQ.convertDocToMessage -> Error: {ex.Message}");
            }

            return message;
        }
    }
}
