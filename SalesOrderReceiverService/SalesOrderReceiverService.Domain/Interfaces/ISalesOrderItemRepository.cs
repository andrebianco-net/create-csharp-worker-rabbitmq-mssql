using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Domain.Interfaces
{
    public interface ISalesOrderItemRepository
    {
        Task<IEnumerable<SalesOrderItem>> GetSalesOrderItemsAsync();
        Task<SalesOrderItem> CreateSalesOrderItemAsync(SalesOrderItem salesOrderItem);
        Task CreateSalesOrderItemsAsync(List<SalesOrderItem> salesOrderItems);
    }
}