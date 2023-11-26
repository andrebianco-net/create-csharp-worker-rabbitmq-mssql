using System.ComponentModel.DataAnnotations.Schema;
using SalesOrderReceiverService.Domain.Validation;

namespace SalesOrderReceiverService.Domain.Entities
{
    public class SalesOrder : Entity
    {
        public decimal Total { get; private set; }
        public DateTime SoldAt { get; private set; }

        public SalesOrder(decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId)
        {
            ValidateDomain(total, soldAt, customerId, categoryId, paymentTypeId);
        }

        public SalesOrder(int id, decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId)
        {
            ValidateDomain(id);
            ValidateDomain(total, soldAt, customerId, categoryId, paymentTypeId);
        }

        public void Update(decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId)
        {
            ValidateDomain(total, soldAt, customerId, categoryId, paymentTypeId);

            ModifiedAt = DateTime.Now;
        }

        private void ValidateDomain(decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId)
        {
            DomainExceptionValidation.When(total <= 0, "Invalid total value");
            DomainExceptionValidation.When(customerId < 0, "Invalid Id value.");
            DomainExceptionValidation.When(categoryId < 0, "Invalid Id value.");
            DomainExceptionValidation.When(paymentTypeId < 0, "Invalid Id value.");

            Total = total;
            SoldAt = soldAt;
            CustomerId = customerId;
            CategoryId = categoryId;
            PaymentTypeId = paymentTypeId;
        }

        public int CustomerId { get; private set; }
        public int CategoryId { get; private set; }
        public int PaymentTypeId { get; private set; }

        public Customer Customer { get; set; }
        public Category Category { get; set; }        
        public PaymentType PaymentType { get; private set; }
    }
}