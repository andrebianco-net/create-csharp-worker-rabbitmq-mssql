using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderReceiverAppService : ISalesOrderReceiverAppService
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly ISalesOrderItemService _salesOrderItemService;
        private readonly ISalesOrderReceiverRabbitMQService _salesOrderReceiverRabbitMQService;
        private readonly ILogger<SalesOrderReceiverAppService> _logger;

        public SalesOrderReceiverAppService(ISalesOrderService salesOrderService,
                                            ISalesOrderItemService salesOrderItemService,
                                            ISalesOrderReceiverRabbitMQService salesOrderReceiverRabbitMQService,
                                            ILogger<SalesOrderReceiverAppService> logger)
        {
            _salesOrderService = salesOrderService;
            _salesOrderItemService = salesOrderItemService;
            _salesOrderReceiverRabbitMQService = salesOrderReceiverRabbitMQService;
            _logger = logger;
        }

        public async Task SalesOrderReceiverRun()
        {

            try
            {

                //First, get data from RabbitMQ queue
                List<MessageDTO> messages = await _salesOrderReceiverRabbitMQService.Receive();

                foreach (MessageDTO message in messages)
                {

                    //Second, insert that data into MSSQL
                    SalesOrderDTO newSalesOrderDto = await _salesOrderService.CreateSalesOrder(message.SalesOrderDto);

                    if (newSalesOrderDto != null)
                    {
                        foreach (SalesOrderItemDTO item in message.SalesOrderItemsDto)
                        {
                            item.SalesOrderId = newSalesOrderDto.Id;
                        }

                        await _salesOrderItemService.CreateSalesOrderItems(message.SalesOrderItemsDto);
                    }
                }

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"SalesOrderReceiverService -> Error: {ex.Message}");
            }

        }
    }

}