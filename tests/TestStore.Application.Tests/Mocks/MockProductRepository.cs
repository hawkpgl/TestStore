using Moq;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;

namespace TestStore.Application.Tests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product(1, "Soup", 0.65m),
                new Product(2, "Bread", 0.80m),
                new Product(3, "Milk", 1.15m),
                new Product(4, "Apples", 1m)
            };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetAll()).Returns(products.AsQueryable());

            return mockRepo;
        }
    }
}
