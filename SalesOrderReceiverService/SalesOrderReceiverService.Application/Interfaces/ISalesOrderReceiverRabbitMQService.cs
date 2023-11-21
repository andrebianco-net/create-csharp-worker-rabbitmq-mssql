using SalesOrderReceiverService.Application.DTOs;

namespace SalesOrderReceiverService.Application.Interfaces
{
    public interface ISalesOrderReceiverRabbitMQService
    {
        Task Receive();
    }
}