using TestStore.Core.Entities;

namespace TestStore.Core.Tests
{
    public class EntityValidationTests
    {
        [Fact]
        public void ProductIsValid()
        {
            //Arrange & Act
            var product = new Product(5, "foo", 0);
            
            //Assert
            Assert.False(product.ValidationResult.IsValid);
        }

        [Fact]
        public void OrderIsValid()
        {
            //Arrange & Act
            var order = new Order();
            order.Id = Guid.Empty;  

            //Assert
            Assert.False(order.IsValid());
        }

        [Fact]
        public void OrderItemShouldBelongToOrder()
        {
            //Arrange & Act
            var orderItem = new OrderItem(1, "foo", 1, 1);

            //Assert
            Assert.False(orderItem.ValidationResult.IsValid);
        }

        [Fact]
        public void OrderItemShouldHaveValidProductId()
        {
            //Arrange & Act
            var orderItem = new OrderItem(0, "foo", 1, 1);

            //Assert
            Assert.False(orderItem.ValidationResult.IsValid);
        }

        [Fact]
        public void OrderItemShouldHaveProductName()
        {
            //Arrange & Act
            var orderItem = new OrderItem(1, "", 1, 1);

            //Assert
            Assert.False(orderItem.ValidationResult.IsValid);
        }

        [Fact]
        public void OrderItemShouldHaveQuantity()
        {
            //Arrange & Act
            var orderItem = new OrderItem(1, "foo", 0, 1);

            //Assert
            Assert.False(orderItem.ValidationResult.IsValid);
        }

        [Fact]
        public void OrderItemShouldHavePrice()
        {
            //Arrange & Act
            var orderItem = new OrderItem(1, "foo", 1, 0);

            //Assert
            Assert.False(orderItem.ValidationResult.IsValid);
        }
    }
}