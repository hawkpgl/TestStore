using MediatR;
using TestStore.Application.Commands.Validations;
using TestStore.Application.ViewModels;
using TestStore.Core.Messages;

namespace TestStore.Application.Commands
{
    public sealed class UpdateOrderItemCommand : Command
    {
        public OrderItemViewModel OrderItemViewModel { get; private set; }

        public UpdateOrderItemCommand(int productId, int quantity)
        {
            OrderItemViewModel = new OrderItemViewModel
            {
                ProductId = productId,
                Quantity = quantity
            };
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
