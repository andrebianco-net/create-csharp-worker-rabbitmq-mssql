using SalesOrderReceiverService.Domain.Validation;

namespace SalesOrderReceiverService.Domain.Entities
{
    public class SalesOrderItem : Entity
    {
        public ICollection<SalesOrder> SalesOrders { get; set; }

        public SalesOrderItem(int salesOrderId, int productId)
        {
            ValidateDomain(salesOrderId, productId);
        }

        public SalesOrderItem(int id, int salesOrderId, int productId)
        {
            ValidateDomain(id);
            ValidateDomain(salesOrderId, productId);
        }

        public void Update(int salesOrderId, int productId, Product product)
        {
            ValidateDomain(SalesOrderId, ProductId);
            SalesOrderId = salesOrderId;
            ProductId = productId;
            Product = product;

            ModifiedAt = DateTime.Now;
        }

        private void ValidateDomain(int salesOrderId, int productId)
        {
            DomainExceptionValidation.When(salesOrderId <= 0, "Invalid Id value.");
            DomainExceptionValidation.When(productId <= 0, "Invalid Id value.");
        }        

        public int SalesOrderId { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public SalesOrder salesOrder { get; set; }
    }    
}