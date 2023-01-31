using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.CurrencyService.Tests
{
    public class CurrencyServiceTests : IClassFixture<TestSetup>
    {
        private ServiceProvider _serviceProvider;
        private IConfiguration _configuration;
        private ICurrencyService _currencyService;

        public CurrencyServiceTests(TestSetup testSetup)
        {
            _serviceProvider = testSetup.ServiceProvider;
            _configuration= _serviceProvider.GetRequiredService<IConfiguration>();
            _currencyService = _serviceProvider.GetRequiredService<ICurrencyService>();
        }

        [Fact]
        public void CurrencyShouldBeInValidFormat()
        {
            //Arrange
            var currency = "Pounds";

            //Act
            var ex = Assert.ThrowsAsync<Exception>(() => _currencyService.ConvertFromUSDAsync(1, "Pounds")).Result;

            //Assert
            Assert.Equal($"Invalid currency format. Currency should in 3 letters format. I.e.: \"GBP\". Value provided: {currency}", ex.Message);
        }

        [Fact]
        public void ApiUrlShouldBeInAppSettings()
        {
            //Arrange & Act & Assert
            Assert.Equal("https://api.apilayer.com/exchangerates_data/convert?to={0}&from=USD&amount={1}", _configuration["CurrencyLayer:apiUrl"]);
        }

        [Fact]
        public void ApiKeyShouldBeInAppSettings()
        {
            //Arrange & Act & Assert
            Assert.Equal("HJHSXMr49CGZRhFWySV2V6x6aCXqkql6", _configuration["CurrencyLayer:APIKey"]);
        }
    }
}