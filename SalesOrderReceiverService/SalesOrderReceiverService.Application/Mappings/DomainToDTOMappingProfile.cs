using AutoMapper;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderDTO>().ReverseMap();
            CreateMap<SalesOrderItem, SalesOrderItemDTO>().ReverseMap();            
        }
    }
}