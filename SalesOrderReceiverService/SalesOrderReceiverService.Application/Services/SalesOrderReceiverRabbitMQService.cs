using AutoMapper;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;
using SalesOrderReceiverService.Domain.Entities;
using SalesOrderReceiverService.Domain.Interfaces;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderReceiverRabbitMQService : ISalesOrderReceiverRabbitMQService
    {
        private ISalesOrderReceiverRabbitMQRepository _salesOrderReceiverRabbitMQRepository;
        private readonly IMapper _mapper;

        public SalesOrderReceiverRabbitMQService(ISalesOrderReceiverRabbitMQRepository salesOrderReceiverRabbitMQRepository, 
                                               IMapper mapper)
        {
            _salesOrderReceiverRabbitMQRepository = salesOrderReceiverRabbitMQRepository;
            _mapper = mapper;
        }

        public async Task Receive()
        {
            throw new NotImplementedException();
        }
    }
}