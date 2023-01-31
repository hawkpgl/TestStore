namespace TestStore.Application.ViewModels
{
    public sealed class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Currency { get; set; }
        public decimal SingleProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
