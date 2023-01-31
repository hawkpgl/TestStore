using AutoMapper;
using TestStore.Application.ViewModels;
using TestStore.Core.Entities;

namespace TestStore.Application.AutoMapper
{
    public sealed class OrderItemToVMMappingProfile : Profile
    {
        public OrderItemToVMMappingProfile()
        {
            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ProductName))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity))
                .ForMember(d => d.SingleProductPrice, o => o.MapFrom(s => s.SingleProductPrice))
                .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.CalculateItemPrice()))
                .ForMember(d => d.Currency, o => o.MapFrom(s => "USD"));
        }
    }
}
