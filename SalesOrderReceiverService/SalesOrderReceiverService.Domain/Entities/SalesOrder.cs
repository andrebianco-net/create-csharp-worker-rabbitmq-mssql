using System.ComponentModel.DataAnnotations.Schema;
using SalesOrderReceiverService.Domain.Validation;

namespace SalesOrderReceiverService.Domain.Entities
{
    public class SalesOrder : Entity
    {
        public decimal Total { get; private set; }
        public DateTime SoldAt { get; private set; }

        public SalesOrder(decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId, string docId)
        {
            ValidateDomain(total, soldAt, customerId, categoryId, paymentTypeId, docId);

            IsClosed = false;
        }

        public SalesOrder(int id, decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId, string docId)
        {
            ValidateDomain(id);
            ValidateDomain(total, soldAt, customerId, categoryId, paymentTypeId, docId);

            IsClosed = false;
        }

        public void Update(decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId, string docId, bool isClosed)
        {
            ValidateDomain(total, soldAt, customerId, categoryId, paymentTypeId, docId);

            ModifiedAt = DateTime.Now;
            IsClosed = isClosed;
        }

        private void ValidateDomain(decimal total, DateTime soldAt, int customerId, int categoryId, int paymentTypeId, string docId)
        {
            DomainExceptionValidation.When(total <= 0, "Invalid total value");
            DomainExceptionValidation.When(customerId < 0, "Invalid Id value.");
            DomainExceptionValidation.When(categoryId < 0, "Invalid Id value.");
            DomainExceptionValidation.When(paymentTypeId < 0, "Invalid Id value.");
            DomainExceptionValidation.When(docId == "", "Invalid Doc Id value.");

            Total = total;
            SoldAt = soldAt;
            CustomerId = customerId;
            CategoryId = categoryId;
            PaymentTypeId = paymentTypeId;
            DocId = docId;
        }

        public int CustomerId { get; private set; }
        public int CategoryId { get; private set; }
        public int PaymentTypeId { get; private set; }
        public string DocId { get; private set; }

        public bool IsClosed { get; private set; }

        public Customer Customer { get; set; }
        public Category Category { get; set; }        
        public PaymentType PaymentType { get; private set; }
    }
}