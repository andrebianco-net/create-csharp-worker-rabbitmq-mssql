using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderReceiverService.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        
        // [Required(ErrorMessage = "Creation date is Required.")]
        // [DisplayName("CreatedAt")]
        // public DateTime CreatedAt { get; set; }

        // [Required(ErrorMessage = "Modification date is Required.")]
        // [DisplayName("ModifiedAt")]
        // public DateTime ModifiedAt { get; set; }

        [Required(ErrorMessage = "The Name is Required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }              
    }
}