using AutoMapper;
using Moq;
using TestStore.Application.Queries;
using TestStore.Application.Queries.QuerryHandlers;
using TestStore.Application.Tests.Mocks;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.Application.Tests.Queries
{
    public class GetOrderTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Order>> _orderRepository;
        private readonly Mock<ICurrencyService> _currencyService;

        public GetOrderTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddMaps(typeof(ApplicationModule).Assembly);
            });

            _mapper = mapperConfig.CreateMapper();
            
            _orderRepository = MockOrderRepository.GetOrderRepository();

            _currencyService = MockCurrencyService.GetCurrencyService();
        }

        [Fact]
        public void GetOrderQueryShouldDefaultCurrencyToUSD()
        {
            //Arrange
            var getOrderQuery = new GetOrderQuery();
            var getOrderQueryHandler = new GetOrderQueryHandler(_orderRepository.Object, _mapper, _currencyService.Object);

            //Act
            var order = getOrderQueryHandler.Handle(getOrderQuery, default).Result;

            //Assert
            Assert.True(order.OrderItems.All(x => x.Currency == "USD"));
        }

        [Fact]
        public void GetConvertedItemShouldUpdateCurrency()
        {
            //Arrange
            var getOrderQuery = new GetConvertedItemQuery(1, "GBP");
            var getOrderQueryHandler = new GetConvertedItemQueryHandler(_orderRepository.Object, _mapper, _currencyService.Object);

            //Act
            var order = getOrderQueryHandler.Handle(getOrderQuery, default).Result;

            //Assert
            Assert.Contains("GBP", order.OrderItems.Where(x => x.ProductId == 1).Select(x => x.Currency));
        }
    }
}
