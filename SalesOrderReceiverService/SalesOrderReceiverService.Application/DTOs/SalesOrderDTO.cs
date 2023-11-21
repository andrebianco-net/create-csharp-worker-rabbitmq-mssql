using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Application.DTOs
{
    public class SalesOrderDTO
    { 
        public int Id { get; set; }

        // [Required(ErrorMessage = "Creation date is Required.")]
        // [DisplayName("CreatedAt")]
        // public DateTime CreatedAt { get; set; }

        // [Required(ErrorMessage = "Modification date is Required.")]
        // [DisplayName("ModifiedAt")]
        // public DateTime ModifiedAt { get; set; }

        [DisplayName("Customers")]
        public int CustomerId { get; private set; }
        
        [DisplayName("Categories")]
        public int CategoryId { get; private set; }
        
        [DisplayName("PaymentTypes")]
        public int PaymentTypeId { get; private set; }
        
        [Required(ErrorMessage = "The Total is Required.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Total")]
        public decimal Total { get; private set; }

        [Required(ErrorMessage = "Sold date is Required.")]
        [DisplayName("SoldAt")]
        public DateTime SoldAt { get; private set; }
        
        [Required(ErrorMessage = "Accepted Order is Required.")]
        [DisplayName("AcceptedOrder")]
        public bool AcceptedOrder { get; private set; }

        public Customer Customer { get; set; }
        public Category Category { get; set; }
        public SalesOrderItem salesOrderItem { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}