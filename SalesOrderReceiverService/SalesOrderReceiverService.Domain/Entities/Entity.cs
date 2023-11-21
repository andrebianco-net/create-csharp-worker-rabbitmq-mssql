using SalesOrderReceiverService.Domain.Validation;

namespace SalesOrderReceiverService.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public void ValidateDomain(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");

            Id = id;

            CreatedAt = DateTime.Now;
        }

    }
}