using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Domain.Vouchers.Enums
{
    public enum VoucherTypeEnum
    {
        Default = 1,
        Expire = 2,
        Unlimited = 3,
        OncePerAccount = 4
    }
}
