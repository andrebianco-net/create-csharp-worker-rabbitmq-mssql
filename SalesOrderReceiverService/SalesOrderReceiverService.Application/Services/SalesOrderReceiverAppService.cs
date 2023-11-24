using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderReceiverAppService : ISalesOrderReceiverAppService
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly ISalesOrderReceiverRabbitMQService _salesOrderReceiverRabbitMQService;
        private readonly ILogger<SalesOrderReceiverAppService> _logger;

        public SalesOrderReceiverAppService(ISalesOrderService salesOrderService,
                                            ISalesOrderReceiverRabbitMQService salesOrderReceiverRabbitMQService,
                                            ILogger<SalesOrderReceiverAppService> logger)
        {
            _salesOrderService = salesOrderService;
            _salesOrderReceiverRabbitMQService = salesOrderReceiverRabbitMQService;
            _logger = logger;
        }

        public async Task SalesOrderReceiverRun()
        {
            List<string> messages = await _salesOrderReceiverRabbitMQService.Receive();
            
        }
    }

}