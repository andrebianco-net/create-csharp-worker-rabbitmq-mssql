using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.RabbitMQ.Interfaces
{
    public interface ISalesOrderReceiverRabbitMQ
    {
        Task<List<Message>> Receive();
    }
}
