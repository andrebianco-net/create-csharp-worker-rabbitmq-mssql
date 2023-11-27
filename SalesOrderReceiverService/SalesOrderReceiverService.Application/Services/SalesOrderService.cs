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
            SalesOrderDTO salesOrderDTO = null;

            IEnumerable<SalesOrder> openSalesOrderByCustomer = await _salesOrderRepository.GetOpenSalesOrdersAsync(salesOrderDto.CustomerId);

            if (!openSalesOrderByCustomer.Where(x => x.DocId == salesOrderDto.DocId).Any())
            {
                SalesOrder salesOrderEntity = _mapper.Map<SalesOrder>(salesOrderDto);
                salesOrderDTO = _mapper.Map<SalesOrderDTO>(await _salesOrderRepository.CreateSalesOrderAsync(salesOrderEntity));
            }

            return salesOrderDTO;
        }
    }
}