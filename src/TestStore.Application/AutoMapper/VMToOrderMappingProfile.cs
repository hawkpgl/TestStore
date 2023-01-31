using AutoMapper;
using TestStore.Application.ViewModels;
using TestStore.Core.Entities;

namespace TestStore.Application.AutoMapper
{
    public sealed class VMToOrderMappingProfile : Profile
    {
        public VMToOrderMappingProfile()
        {
            CreateMap<OrderViewModel, Order>()
                .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.TotalPrice))
                .ForMember(d => d.OrderItems, o => o.MapFrom(s => s.OrderItems));
        }
    }
}
