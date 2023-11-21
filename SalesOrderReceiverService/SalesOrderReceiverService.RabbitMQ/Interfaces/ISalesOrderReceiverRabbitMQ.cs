namespace SalesOrderReceiverService.RabbitMQ.Interfaces
{
    public interface ISalesOrderReceiverRabbitMQ
    {
        Task Receive();
    }
}
