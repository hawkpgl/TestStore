using AutoMapper;
using MediatR;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;

namespace TestStore.Application.Commands.CommandHandlers
{
    public sealed class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, bool>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IProductRepository _productRepository;

        public DeleteOrderItemCommandHandler(IRepository<Order> orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteOrderItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return false;

            var order = _orderRepository.GetAll().FirstOrDefault();

            if (order == null) order = new Order();

            var product = _productRepository.GetById(command.ProductId);

            if (product == null) return false;

            order.RemoveItem(command.ProductId);

            _orderRepository.InsertOrUpdate(order);
            
            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
