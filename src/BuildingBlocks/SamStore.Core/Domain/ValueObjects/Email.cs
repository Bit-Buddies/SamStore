using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SamStore.Core.Domain.ValueObjects
{
    public class Email : IValueObject
    {
        public string Address { get; private set; }

        protected Email() { }
        public Email(string address) {
            if (!Validate(address))
                throw new DomainException("Invalid e-mail");

            Address = address;
        }

        public static bool Validate(string address)
        {
            return Regex.IsMatch(address, "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }
    }
}
