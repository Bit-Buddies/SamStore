using SamStore.Core.CQRS.Commands;

namespace SamStore.Cliente.Application.Commands.Customers
{
    public class RegisterCustomerCommand : Command<bool>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }

        public RegisterCustomerCommand(Guid id, string name, string email, string cPF)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = email;
            CPF = cPF;
        }
    }
}
