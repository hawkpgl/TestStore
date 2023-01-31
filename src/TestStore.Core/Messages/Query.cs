using FluentValidation.Results;
using MediatR;

namespace TestStore.Core.Messages
{
    public abstract class Query<T> : IRequest<T>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
