using AutoMapper;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderItemService : ISalesOrderItemService
    {
        private ISalesOrderItemRepository _salesOrderItemRepository;
        private readonly IMapper _mapper;

        public SalesOrderItemService(ISalesOrderItemRepository salesOrderItemRepository, IMapper mapper)
        {
            _salesOrderItemRepository = salesOrderItemRepository;
            _mapper = mapper;
        }        

        public async Task<SalesOrderItemDTO> CreateSalesOrderItem(SalesOrderItemDTO salesOrderItemDto)
        {
            SalesOrderItem salesOrderItemEntity = _mapper.Map<SalesOrderItem>(salesOrderItemDto);
            return _mapper.Map<SalesOrderItemDTO>(await _salesOrderItemRepository.CreateSalesOrderItemAsync(salesOrderItemEntity));
        }

        public async Task CreateSalesOrderItems(List<SalesOrderItemDTO> salesOrderItemsDto)
        {
            List<SalesOrderItem> salesOrderItemsEntity = _mapper.Map<List<SalesOrderItem>>(salesOrderItemsDto);
            await _salesOrderItemRepository.CreateSalesOrderItemsAsync(salesOrderItemsEntity);
        }
    }
}