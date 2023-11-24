namespace SalesOrderReceiverService.RabbitMQ.Interfaces
{
    public interface ISalesOrderReceiverRabbitMQ
    {
        Task<List<string>> Receive();
    }
}
