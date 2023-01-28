using FluentValidation.Results;
using MediatR;

namespace SamStore.Core.CQRS.Commands
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            ValidationResult = new ValidationResult();
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
