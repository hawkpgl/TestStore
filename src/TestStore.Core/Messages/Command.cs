using FluentValidation.Results;
using MediatR;

namespace TestStore.Core.Messages
{
    public abstract class Command : IRequest<bool>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        { 
            throw new NotImplementedException();
        }
    }
}
