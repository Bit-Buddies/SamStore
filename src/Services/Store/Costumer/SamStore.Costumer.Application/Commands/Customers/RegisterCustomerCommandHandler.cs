using FluentValidation.Results;
using SamStore.Costumer.Application.Events.Customers;
using SamStore.Costumer.Domain.Customers;
using SamStore.Costumer.Domain.Interfaces;
using SamStore.Core.CQRS.Commands;
using SamStore.Core.Extensions;

namespace SamStore.Costumer.Application.Commands.Customers
{
    public class RegisterCustomerCommandHandler : CommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<ValidationResult> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            string cpf = request.CPFNumber.GetOnlyNumbers();

            Customer customer = await _customerRepository.GetByCPF(cpf);

            if(customer != null)
            {
                AddError("CPF already in use");
                return ValidationResult;
            }

            customer = new Customer(request.Id, request.Name, request.EmailAddress, cpf);

            _customerRepository.Insert(customer);

            customer.AddNotificationEvent(new RegisteredCustomerEvent(customer.Id, customer.Name, customer.Email.Address, customer.CPF.Number));

            return await Persist(_customerRepository.UnitOfWork);
        }
    }
}
