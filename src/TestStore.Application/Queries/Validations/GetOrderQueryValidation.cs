using FluentValidation;

namespace TestStore.Application.Queries.Validations
{
    public class GetOrderQueryValidation : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidation()
        {
            RuleFor(c => c.Currency)
                .Length(3)
                .WithMessage("Invalid currency format. Currency must be in 3 letters. I.e.: \"GBP\".");
        }
    }
}
