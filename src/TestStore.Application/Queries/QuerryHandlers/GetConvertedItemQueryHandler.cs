using AutoMapper;
using MediatR;
using TestStore.Application.ViewModels;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;
using TestStore.Core.Messages;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.Application.Queries.QuerryHandlers
{
    public class GetConvertedItemQueryHandler : IRequestHandler<GetConvertedItemQuery, OrderViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        private readonly ICurrencyService _currencyService;

        public GetConvertedItemQueryHandler(IRepository<Order> orderRepository,
                                    IMapper mapper,
                                    ICurrencyService currencyService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _currencyService = currencyService;
        }

        public async Task<OrderViewModel> Handle(GetConvertedItemQuery query, CancellationToken cancellationToken)
        {
            if (!query.IsValid()) throw new Exception($"Invalid query: {string.Join(", ", query.ValidationResult.Errors.Select(x => x.ErrorMessage))}");

            //This would fetch the Order for a client, session, etc. Parameters would be in GetOrderQuery 
            var order = _orderRepository.GetAll().FirstOrDefault();

            if (order == null)
            {
                order = new Order();
            }

            if (!order.OrderItems.Any(x => x.ProductId == query.ProductId)) throw new Exception($"The product doesn't belong in the order");

            var orderViewModel = _mapper.Map<OrderViewModel>(order);

            if (query.Currency != "USD" && 
                order.TotalPrice > 0 && 
                orderViewModel.OrderItems.Any(x => x.ProductId == query.ProductId && x.TotalPrice > 0))
            {
                await UpdateOrderItemViewModel(query, orderViewModel);
                orderViewModel.TotalPrice = 0;
            }

            return orderViewModel;
        }

        private async Task UpdateOrderItemViewModel(GetConvertedItemQuery query, OrderViewModel orderViewModel)
        {
            var orderItemViewModel = orderViewModel.OrderItems.Single(x => x.ProductId == query.ProductId);
            orderItemViewModel.SingleProductPrice = await _currencyService.ConvertFromUSDAsync(orderItemViewModel.SingleProductPrice, query.Currency);
            orderItemViewModel.TotalPrice = orderItemViewModel.SingleProductPrice * orderItemViewModel.Quantity;
            orderItemViewModel.Currency = query.Currency;
        }
    }
}
