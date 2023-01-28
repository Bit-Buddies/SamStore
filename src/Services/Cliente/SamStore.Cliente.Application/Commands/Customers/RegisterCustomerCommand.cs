using FluentValidation;
using SamStore.Core.CQRS.Commands;
using SamStore.Core.Domain.Utils;
using SamStore.Core.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SamStore.Cliente.Application.Commands.Customers
{
    public class RegisterCustomerCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string EmailAddress { get; private set; }
        public string CPFNumber { get; private set; }

        public RegisterCustomerCommand(Guid id, string name, string email, string cPF)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            EmailAddress = email;
            CPFNumber = cPF;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        private class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
        {
            public RegisterCustomerCommandValidator()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Invalid ID");

                RuleFor(c => c.Name)
                    .Must(n => !n.IsNullOrWhiteSpace())
                    .WithMessage("Name is required");

                RuleFor(c => c.EmailAddress)
                    .Must(e => Email.Validate(e))
                    .WithMessage("Invalid Email");

                RuleFor(c => c.CPFNumber)
                    .Must(c => CPF.Validate(c))
                    .WithMessage("Invalid CPF");
            }
        }
    }
}
