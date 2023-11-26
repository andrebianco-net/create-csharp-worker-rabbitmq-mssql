using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Application.DTOs
{
    public class MessageDTO
    { 
        public SalesOrderDTO SalesOrderDto { get; set; }

        public List<SalesOrderItemDTO> SalesOrderItemsDto { get; set; }
    }
}