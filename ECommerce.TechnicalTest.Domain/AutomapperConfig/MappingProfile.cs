using AutoMapper;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Domain.DTO;

namespace ECommerce.TechnicalTest.Domain.AutomapperConfig;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<OrderItemDetail, OrderItemDetailDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
    }

}