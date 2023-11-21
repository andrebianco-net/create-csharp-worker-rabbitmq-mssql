using SalesOrderReceiverService.Application.DTOs;

namespace SalesOrderReceiverService.Application.Interfaces
{
    public interface ISalesOrderService
    {
        Task<SalesOrderDTO> CreateSalesOrder(SalesOrderDTO salesOrderDto);
    }    
}