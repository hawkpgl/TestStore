using TestStore.Application.Queries.Validations;
using TestStore.Application.ViewModels;
using TestStore.Core.Messages;

namespace TestStore.Application.Queries
{
    public sealed class GetConvertedItemQuery : Query<OrderViewModel>
    { 
        public int ProductId { get; private set; }
        public string Currency { get; private set; }

        public GetConvertedItemQuery(int productId, string currency)
        {
            ProductId = productId;  
            Currency = currency;
        }

        public override bool IsValid()
        {
            ValidationResult = new GetConvertedItemQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
