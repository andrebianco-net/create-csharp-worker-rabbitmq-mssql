using SalesOrderReceiverService.Domain.Validation;

namespace SalesOrderReceiverService.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public Product(string name)
        {
            ValidateDomain(name);
        }

        public Product(int id, string name)
        {
            ValidateDomain(id);
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);

            ModifiedAt = DateTime.Now;
        }

        public ICollection<SalesOrderItem> SalesOrderItems { get; set; }                        

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3, 
                "Invalid name, too short, minimum 3 characters.");

            Name = name;
        }
    }    
}