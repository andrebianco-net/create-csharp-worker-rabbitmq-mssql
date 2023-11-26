using SalesOrderReceiverService.Application.DTOs;

namespace SalesOrderReceiverService.Application.Interfaces
{
    public interface ISalesOrderReceiverRabbitMQService
    {
        Task<List<MessageDTO>> Receive();
    }
}