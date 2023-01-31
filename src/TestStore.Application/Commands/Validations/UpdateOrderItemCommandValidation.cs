using FluentValidation;

namespace TestStore.Application.Commands.Validations
{
    public class UpdateOrderItemCommandValidation : AbstractValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemCommandValidation()
        {
            RuleFor(c => c.OrderItemViewModel.ProductId)
                .GreaterThan(0)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.OrderItemViewModel.ProductId)
                .LessThanOrEqualTo(4)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.OrderItemViewModel.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage("The minimum quantity is 1.");
        }
    }
}
