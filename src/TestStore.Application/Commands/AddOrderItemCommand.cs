using MediatR;
using TestStore.Application.Commands.Validations;
using TestStore.Application.ViewModels;
using TestStore.Core.Messages;

namespace TestStore.Application.Commands
{
    public sealed class AddOrderItemCommand : Command
    {
        public OrderItemViewModel OrderItemViewModel { get; private set; }

        public AddOrderItemCommand(int productId, int quantity)
        {
            OrderItemViewModel = new OrderItemViewModel
            {
                ProductId = productId,
                Quantity = quantity
            };
        }

        public override bool IsValid()
        {
            ValidationResult = new AddOrderItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
