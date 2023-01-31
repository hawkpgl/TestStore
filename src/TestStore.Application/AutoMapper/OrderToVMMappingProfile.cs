using AutoMapper;
using TestStore.Application.ViewModels;
using TestStore.Core.Entities;

namespace TestStore.Application.AutoMapper
{
    public sealed class OrderToVMMappingProfile : Profile
    {
        public OrderToVMMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.TotalPrice))
                .ForMember(d => d.OrderItems, o => o.MapFrom(s => s.OrderItems));
        }
    }
}
