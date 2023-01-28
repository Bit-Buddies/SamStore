using FluentValidation.Results;
using SamStore.Cliente.Domain.Customers;
using SamStore.Cliente.Domain.Interfaces;
using SamStore.Core.CQRS.Commands;

namespace SamStore.Cliente.Application.Commands.Customers
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

            Customer customer = await _customerRepository.GetByCPF(request.CPFNumber);

            if(customer != null)
            {
                AddError("CPF already in use");
                return ValidationResult;
            }

            customer = new Customer(request.Id, request.Name, request.EmailAddress, request.CPFNumber);

            _customerRepository.Add(customer);

            return await Persist(_customerRepository.UnitOfWork);
        }
    }
}
