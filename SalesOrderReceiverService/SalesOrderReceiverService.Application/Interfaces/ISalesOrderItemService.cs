using SalesOrderReceiverService.Application.DTOs;

namespace SalesOrderReceiverService.Application.Interfaces
{
    public interface ISalesOrderItemService
    {
        Task<SalesOrderItemDTO> CreateSalesOrderItem(SalesOrderItemDTO salesOrderItemDto);

        Task CreateSalesOrderItems(List<SalesOrderItemDTO> salesOrderItemsDto);
    }    
}