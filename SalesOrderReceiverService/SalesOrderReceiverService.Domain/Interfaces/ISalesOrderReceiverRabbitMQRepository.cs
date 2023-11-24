using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Domain.Interfaces
{
    public interface ISalesOrderReceiverRabbitMQRepository
    {
        Task<List<string>> Receive();
    }
}