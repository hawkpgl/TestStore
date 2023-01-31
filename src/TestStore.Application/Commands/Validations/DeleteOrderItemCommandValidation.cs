using FluentValidation;

namespace TestStore.Application.Commands.Validations
{
    public class DeleteOrderItemCommandValidation : AbstractValidator<DeleteOrderItemCommand>
    {
        public DeleteOrderItemCommandValidation()
        {
            RuleFor(c => c.ProductId)
                .GreaterThan(0)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.ProductId)
                .LessThanOrEqualTo(4)
                .WithMessage("Invalid product id.");
        }
    }
}
