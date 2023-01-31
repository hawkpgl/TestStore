using Moq;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.Application.Tests.Mocks
{
    public static class MockCurrencyService
    {
        public static Mock<ICurrencyService> GetCurrencyService()
        {
            var mockService = new Mock<ICurrencyService>();

            mockService.Setup(h => h.ConvertFromUSDAsync(It.IsAny<decimal>(), It.IsAny<string>()))
                       .Returns(Task.FromResult(5m));

            return mockService;
        }
    }
}
