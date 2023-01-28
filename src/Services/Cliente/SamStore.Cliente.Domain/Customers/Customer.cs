using SamStore.Core.Domain;
using SamStore.Core.Domain.ValueObjects;
using SamStore.Core.Infrastructure.Data;

namespace SamStore.Cliente.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public CPF CPF { get; private set; }
        public Phone Phone { get; private set; }

        public Guid AddressId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }

        protected Customer() { }
        public Customer(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            CPF = new CPF(cpf);
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        public void ChangeAddress(CustomerAddress address)
        {
            CustomerAddress = address;
        }
    }
}
