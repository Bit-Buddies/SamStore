using FluentValidation.Results;
using MediatR;
using SamStore.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.CQRS.Commands
{
    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, ValidationResult> where TRequest : Command
    {
        public ValidationResult ValidationResult { get; private set; } = new ValidationResult();
        public abstract Task<ValidationResult> Handle(TRequest request, CancellationToken cancellationToken);

        public CommandHandler<TRequest> AddError(string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure() { ErrorMessage = errorMessage });
            return this;
        }

        public CommandHandler<TRequest> AddError(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
            return this;
        }

        public CommandHandler<TRequest> AddError(string propertyName, string errorMessage, string errorCode)
        { 
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage) { ErrorCode = errorCode });
            return this;
        }

        public async Task<ValidationResult> Persist(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork.Commit())
                AddError("An errour as occurred while trying to save the data");

            return ValidationResult;
        }
    }
}
