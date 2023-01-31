namespace TestStore.Application.ViewModels
{
    public sealed class OrderViewModel
    {
        public decimal TotalPrice { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
