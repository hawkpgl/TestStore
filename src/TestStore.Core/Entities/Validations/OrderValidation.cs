using FluentValidation;

namespace TestStore.Core.Entities.Validations
{
    internal sealed class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid order id.");
        }
    }
}
