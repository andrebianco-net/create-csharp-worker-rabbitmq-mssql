using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderReceiverAppService : ISalesOrderReceiverAppService
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly ILogger<SalesOrderReceiverAppService> _logger;

        public SalesOrderReceiverAppService(ISalesOrderService salesOrderService,
                                            ILogger<SalesOrderReceiverAppService> logger)
        {
            _salesOrderService = salesOrderService;
            _logger = logger;
        }

        public async Task SalesOrderReceiverRun()
        {
            //var test = _salesOrderService.CreateSalesOrder();
        }
    }

}