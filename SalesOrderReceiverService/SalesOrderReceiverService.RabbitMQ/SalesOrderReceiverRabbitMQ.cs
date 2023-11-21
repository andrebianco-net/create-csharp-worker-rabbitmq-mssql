using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SalesOrderReceiverService.RabbitMQ.Interfaces;

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

        public async Task Receive()
        {
            throw new NotImplementedException();
        }
    }
}
