using MediatR;
using TestStore.Application.Commands.Validations;
using TestStore.Application.ViewModels;
using TestStore.Core.Messages;

namespace TestStore.Application.Commands
{
    public sealed class DeleteOrderItemCommand : Command
    {
        public int ProductId { get; private set; }

        public DeleteOrderItemCommand(int productId)
        {
            ProductId = productId;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteOrderItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
