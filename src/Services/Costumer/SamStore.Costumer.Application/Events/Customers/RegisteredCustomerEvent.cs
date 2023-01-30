using SamStore.Core.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Costumer.Application.Events.Customers
{
    public class RegisteredCustomerEvent : NotificationEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }

        public RegisteredCustomerEvent(Guid id, string name, string email, string cPF)
        {
            Id = id;
            Name = name;
            Email = email;
            CPF = cPF;
        }
    }
}
