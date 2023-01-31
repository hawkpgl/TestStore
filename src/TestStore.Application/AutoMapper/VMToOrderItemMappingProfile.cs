using AutoMapper;
using TestStore.Application.ViewModels;
using TestStore.Core.Entities;

namespace TestStore.Application.AutoMapper
{
    public sealed class VMToOrderItemMappingProfile : Profile
    {
        public VMToOrderItemMappingProfile()
        {
            CreateMap<OrderItemViewModel, OrderItem>()
                .ConstructUsing(s => new OrderItem(s.ProductId, s.ProductName, s.Quantity, s.SingleProductPrice));
        }
    }
}
