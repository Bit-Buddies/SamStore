using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SamStore.Core.Domain.ValueObjects
{
    public class Phone
    {
        public string PrincipalPhone { get; private set; }
        public string SecundaryPhone { get; private set; }

        public Phone(string principalPhone, string secundaryPhone)
        {
            if (string.IsNullOrWhiteSpace(principalPhone))
                throw new Exception("Phone is required");

            if (!Validate(principalPhone))
                throw new Exception("Principal phone is not valid.");

            if (!string.IsNullOrWhiteSpace(secundaryPhone))
            {
                if (!Validate(secundaryPhone))
                    throw new Exception("Secundary phone is not valid.");
            }

            PrincipalPhone = principalPhone;
            SecundaryPhone = secundaryPhone ?? string.Empty;
        }

        public static bool Validate(string phone)
        {
            return Regex.IsMatch(phone, "^(?:(?:\\+|00)?(55))(?:\\(?([1-9][0-9])\\)?)(?:((?:9\\d|[2-9])\\d{3})(\\d{4}))$");
        }
    }
}
