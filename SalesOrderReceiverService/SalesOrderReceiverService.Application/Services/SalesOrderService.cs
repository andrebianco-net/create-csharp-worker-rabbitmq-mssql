using AutoMapper;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private ISalesOrderRepository _salesOrderRepository;
        private readonly IMapper _mapper;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository, IMapper mapper)
        {
            _salesOrderRepository = salesOrderRepository;
            _mapper = mapper;
        }        

        public async Task<SalesOrderDTO> CreateSalesOrder(SalesOrderDTO salesOrderDto)
        {
            SalesOrder salesOrderEntity = _mapper.Map<SalesOrder>(salesOrderDto);
            return _mapper.Map<SalesOrderDTO>(await _salesOrderRepository.CreateSalesOrderAsync(salesOrderEntity));
        }
    }
}