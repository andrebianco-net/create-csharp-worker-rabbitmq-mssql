using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderReceiverService.Application.DTOs
{
    public class SalesOrderItemDTO
    {
        public int Id { get; set; }
        
        public int SalesOrderId { get; set; }

        public int ProductId { get; set; }
    }
}