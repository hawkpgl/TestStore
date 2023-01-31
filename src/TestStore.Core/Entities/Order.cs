using TestStore.Core.DomainObjects;
using TestStore.Core.Entities.Validations;

namespace TestStore.Core.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public decimal TotalPrice { get; private set; }

        public Order()
        {
            _orderItems = new List<OrderItem>();

            IsValid();
        }

        public bool OrderItemExists(OrderItem item)
        {
            return _orderItems.Any(p => p.ProductName == item.ProductName);
        }

        public void CalculateOrderValue()
        {
            TotalPrice = OrderItems.Sum(x => x.CalculateItemPrice());

            //If there were vouchers, discounts, etc, apply them here
        }

        public void AddItem(OrderItem item)
        {
            if (!item.IsValid()) return;

            item.AddToOrder(Id);

            if (OrderItemExists(item))
            {
                var existingItem = _orderItems.Single(p => p.ProductId == item.ProductId);
                existingItem.UpdateItemQuantity(existingItem.Quantity + item.Quantity);
                item = existingItem;

                _orderItems.Remove(existingItem);
            }
            
            _orderItems.Add(item);

            CalculateOrderValue();
        }

        public void UpdateItem(OrderItem item)
        {
            if (!item.IsValid()) return;

            item.AddToOrder(Id);

            if (OrderItemExists(item))
            {
                var existingItem = _orderItems.Single(p => p.ProductId == item.ProductId);
                existingItem.UpdateItemQuantity(item.Quantity);
                item = existingItem;

                _orderItems.Remove(existingItem);
            }

            _orderItems.Add(item);

            CalculateOrderValue();
        }

        public void RemoveItem(int productId)
        {
            var existingItem = _orderItems.FirstOrDefault(p => p.ProductId == productId);

            //TODO: handle Domain Exceptions
            if (existingItem == null) throw new DomainException("The item does not belong in the order.");

            _orderItems.Remove(existingItem);

            CalculateOrderValue();
        }

        public override bool IsValid()
        {
            ValidationResult = new OrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
