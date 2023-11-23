using AutoMapper;
using Microsoft.Extensions.Logging;
using SalesOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.RabbitMQ.Interfaces;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
    public class SalesOrderReceiverRabbitMQRepository : ISalesOrderReceiverRabbitMQRepository
    {
        private readonly ISalesOrderReceiverRabbitMQ _salesOrderReceiverRabbitMQ;
        private readonly IMapper _mapper;
        private readonly ILogger<SalesOrderReceiverRabbitMQRepository> _logger;

        public SalesOrderReceiverRabbitMQRepository(ISalesOrderReceiverRabbitMQ salesOrderReceiverRabbitMQ,
                                     IMapper mapper,
                                     ILogger<SalesOrderReceiverRabbitMQRepository> logger)
        {
            _salesOrderReceiverRabbitMQ = salesOrderReceiverRabbitMQ;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Receive()
        {
            throw new NotImplementedException();
        }
    }
}