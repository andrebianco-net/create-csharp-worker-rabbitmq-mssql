using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Domain.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetSalesOrdersAsync();
        Task<SalesOrder> CreateSalesOrderAsync(SalesOrder salesOrder);
        Task<IEnumerable<SalesOrder>> GetOpenSalesOrdersAsync(int customerId);
    }
}