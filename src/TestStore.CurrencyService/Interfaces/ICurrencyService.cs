namespace TestStore.CurrencyService.Interfaces
{
    public interface ICurrencyService
    {
        public Task<decimal> ConvertFromUSDAsync(decimal value, string currency);
    }
}
