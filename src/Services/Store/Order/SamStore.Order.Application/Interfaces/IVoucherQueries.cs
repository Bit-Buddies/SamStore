using SamStore.Order.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Application.Interfaces
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> GetByKey(string key);
    }
}
