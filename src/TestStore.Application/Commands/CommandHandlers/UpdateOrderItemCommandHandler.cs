using AutoMapper;
using MediatR;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;

namespace TestStore.Application.Commands.CommandHandlers
{
    public sealed class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        private readonly IProductRepository _productRepository;

        public UpdateOrderItemCommandHandler(IMapper mapper, IRepository<Order> orderRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateOrderItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return false;

            var order = _orderRepository.GetAll().FirstOrDefault();

            if (order == null) order = new Order();

            var product = _productRepository.GetById(command.OrderItemViewModel.ProductId);

            if (product == null) return false;

            var orderItemViewModel = command.OrderItemViewModel;
            orderItemViewModel.ProductName = product.Name;
            orderItemViewModel.SingleProductPrice = product.Price;

            order.UpdateItem(_mapper.Map<OrderItem>(orderItemViewModel));

            _orderRepository.InsertOrUpdate(order);
            
            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
