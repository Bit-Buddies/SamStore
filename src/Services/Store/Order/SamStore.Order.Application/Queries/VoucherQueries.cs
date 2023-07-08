using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SamStore.Order.Application.Interfaces;
using SamStore.Order.Application.Models;
using SamStore.Order.Domain.Interfaces;
using SamStore.Order.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Application.Queries
{
    public class VoucherQueries : IVoucherQueries
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IMapper _mapper;

        public VoucherQueries(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _mapper = mapper;
        }

        public async Task<VoucherDTO> GetByKey(string key)
        {
            Voucher voucher = await _voucherRepository.FirstOrDefaultAsync(x => x.Key == key);

            if (voucher == null)
                return null;

            if (!voucher.IsValid())
                return null;

            VoucherDTO voucherDTO = _mapper.Map<VoucherDTO>(voucher);

            return voucherDTO;
        }
    }
}
