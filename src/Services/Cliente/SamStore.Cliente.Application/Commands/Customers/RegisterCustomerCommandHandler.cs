using FluentValidation.Results;
using SamStore.Core.CQRS.Commands;

namespace SamStore.Cliente.Application.Commands.Customers
{
    public class RegisterCustomerCommandHandler : CommandHandler<RegisterCustomerCommand>
    {
        public override async Task<ValidationResult> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            return ValidationResult;
        }
    }
}
