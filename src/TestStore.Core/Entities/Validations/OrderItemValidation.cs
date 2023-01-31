using FluentValidation;

namespace TestStore.Core.Entities.Validations
{
    internal sealed class OrderItemValidation : AbstractValidator<OrderItem>
    {
        public OrderItemValidation()
        {
            RuleFor(c => c.ProductId)
                .GreaterThan(0)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.ProductId)
                .LessThanOrEqualTo(4)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.ProductName)
                .NotEmpty()
                .WithMessage("The product name can't be empty.");

            RuleFor(c => c.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage("The minimum quantity is 1.");

            RuleFor(c => c.SingleProductPrice)
                .GreaterThan(0)
                .WithMessage("The product price must be greater than 0.");
        }
    }
}
