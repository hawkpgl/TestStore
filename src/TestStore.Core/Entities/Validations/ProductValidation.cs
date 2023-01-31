using FluentValidation;

namespace TestStore.Core.Entities.Validations
{
    internal sealed class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.Id)
                .LessThanOrEqualTo(4)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.Price)
                .GreaterThan(0)
                .WithMessage("The product price must be greater than 0.");
        }
    }
}
