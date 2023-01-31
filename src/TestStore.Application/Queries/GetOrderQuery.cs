using TestStore.Application.Queries.Validations;
using TestStore.Application.ViewModels;
using TestStore.Core.Messages;

namespace TestStore.Application.Queries
{
    public sealed class GetOrderQuery : Query<OrderViewModel>
    { 
        public string Currency { get; private set; }

        public GetOrderQuery(string currency = "USD")
        {
            Currency = currency;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetOrderQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
