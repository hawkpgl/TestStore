namespace TestStore.CurrencyService.ViewModels
{
    public sealed class ConvertViewModel
    {
        public string Date { get; set; }
        public Query Query { get; set; }
        public decimal Result { get; set; }
        public bool Success { get; set; }
    }

    public sealed class Query
    {
        public decimal Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
