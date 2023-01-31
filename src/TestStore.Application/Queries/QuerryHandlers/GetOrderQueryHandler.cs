using AutoMapper;
using MediatR;
using TestStore.Application.ViewModels;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;
using TestStore.Core.Messages;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.Application.Queries.QuerryHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        private readonly ICurrencyService _currencyService;

        public GetOrderQueryHandler(IRepository<Order> orderRepository,
                                    IMapper mapper,
                                    ICurrencyService currencyService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _currencyService = currencyService;
        }

        public async Task<OrderViewModel> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            if (!query.IsValid()) throw new Exception($"Invalid query: {string.Join(", ", query.ValidationResult.Errors.Select(x => x.ErrorMessage))}");

            //This would fetch the Order for a client, session, etc. Parameters would be in GetOrderQuery 
            var order = _orderRepository.GetAll().FirstOrDefault();

            if (order == null)
            {
                order = new Order();
            }

            var orderViewModel = _mapper.Map<OrderViewModel>(order);

            if (query.Currency != "USD" && order.TotalPrice > 0)
            {
                orderViewModel.TotalPrice = await _currencyService.ConvertFromUSDAsync(order.TotalPrice, query.Currency);
                orderViewModel.OrderItems.ForEach(x => { x.Currency = query.Currency; x.SingleProductPrice = 0; x.TotalPrice = 0; }) ;
            }

            return orderViewModel;
        }
    }
}
