using TestStore.Core.DomainObjects;
using TestStore.Core.Entities.Validations;

namespace TestStore.Core.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public int ProductId { get; private set; }        
        public string ProductName { get; private set; }
        public int Quantity { get; set; }
        public decimal SingleProductPrice { get; set; }

        //EF navigation property
        public virtual Order Order { get; set; }

        public OrderItem(int productId, string productName, int quantity, decimal singleProductPrice)
            : base()
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            SingleProductPrice = singleProductPrice;

            IsValid();
        }

        internal void AddToOrder(Guid orderId)
        {
            OrderId = orderId;
        }

        internal void UpdateItemQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public decimal CalculateItemPrice()
        {
            return Quantity * SingleProductPrice;
        }

        public override bool IsValid()
        {
            ValidationResult = new OrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
