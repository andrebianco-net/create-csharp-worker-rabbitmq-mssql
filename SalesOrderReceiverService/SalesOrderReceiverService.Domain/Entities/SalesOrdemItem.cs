namespace SalesOrderReceiverService.Domain.Entities
{
    public class SalesOrderItem : Entity
    {
        public ICollection<SalesOrder> SalesOrders { get; set; }
        public int SalesOrderId { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public SalesOrder salesOrder { get; set; }
    }    
}