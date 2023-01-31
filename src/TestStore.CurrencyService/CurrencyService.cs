using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using TestStore.CurrencyService.Interfaces;
using TestStore.CurrencyService.ViewModels;

namespace TestStore.CurrencyService
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrencyService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<decimal> ConvertFromUSDAsync(decimal value, string currency)
        {
            if (value <= 0) return value;
            
            if (currency.Length != 3) throw new Exception($"Invalid currency format. Currency should in 3 letters format. I.e.: \"GBP\". Value provided: {currency}");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format(_configuration["CurrencyLayer:APIKey"], currency, value))
            {
                Headers = { { "apikey", _configuration["CurrencyLayer:APIKey"] } }
            };

            var httpClient = _httpClientFactory.CreateClient();
            
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadFromJsonAsync<ConvertViewModel>();
                if (result != null) return result.Result;
            }

            //This should be a notification to be handled somewhere
            throw new Exception($"Error in the currency API: {httpResponseMessage.StatusCode} - {await httpResponseMessage.Content.ReadAsStringAsync()}");
        }
    }
}
