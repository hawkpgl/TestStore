using Moq;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;

namespace TestStore.Application.Tests.Mocks
{
    public static class MockOrderRepository
    {
        public static Mock<IRepository<Order>> GetOrderRepository()
        {
            var order = new Order();
            order.AddItem(new OrderItem(1, "Soup", 1, 0.65m));
            order.AddItem(new OrderItem(4, "Apples", 2, 1m));

            var orders = new List<Order>{ order };

            var mockRepo = new Mock<IRepository<Order>>();
            mockRepo.Setup(r => r.GetAll()).Returns(orders.AsQueryable());

            return mockRepo;
        }
    }
}
