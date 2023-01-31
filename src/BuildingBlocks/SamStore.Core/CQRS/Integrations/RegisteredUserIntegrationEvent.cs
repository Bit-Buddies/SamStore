using SamStore.Core.CQRS.Integrations.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.CQRS.Integrations
{
    public class RegisteredUserIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public RegisteredUserIntegrationEvent(Guid id, string name, string cPF, string email)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            Email = email;
        }
    }
}
