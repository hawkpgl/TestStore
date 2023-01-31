using FluentValidation;

namespace TestStore.Application.Queries.Validations
{
    public class GetConvertedItemQueryValidation : AbstractValidator<GetConvertedItemQuery>
    {
        public GetConvertedItemQueryValidation()
        {
            RuleFor(c => c.ProductId)
                .GreaterThan(0)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.ProductId)
                .LessThanOrEqualTo(4)
                .WithMessage("Invalid product id.");

            RuleFor(c => c.Currency)
                .Length(3)
                .WithMessage("Invalid currency format. Currency must be in 3 letters. I.e.: \"GBP\".");
        }
    }
}
