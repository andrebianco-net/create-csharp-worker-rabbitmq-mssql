using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Application.DTOs
{
    public class SalesOrderDTO
    { 
        public int Id { get; set; }

        public int CustomerId { get; set; }
        
        public int CategoryId { get; set; }
        
        public int PaymentTypeId { get; set; }
        
        [Required(ErrorMessage = "The Total is Required.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Total")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Sold date is Required.")]
        [DisplayName("SoldAt")]
        public DateTime SoldAt { get; set; }
        
        public Customer Customer { get; set; }
        public Category Category { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}