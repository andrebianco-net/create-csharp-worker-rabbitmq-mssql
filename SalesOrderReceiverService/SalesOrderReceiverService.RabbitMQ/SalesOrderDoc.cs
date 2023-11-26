namespace SalesOrderReceiverService.RabbitMQ
{    
    public class SalesOrderDoc
    {
        public string Id { get; set; }
        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public List<int> ListProductId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Total { get; set; }
        public DateTime SoldAt { get; set; }
        public DateTime createdAt { get; set; }
        public bool AcceptedOrder { get; set; }
    }
}