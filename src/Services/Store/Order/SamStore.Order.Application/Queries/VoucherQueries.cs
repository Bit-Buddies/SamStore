using AutoMapper;
using FluentValidation;
using SamStore.Core.CQRS;
using SamStore.Order.Application.Interfaces;
using SamStore.Order.Application.Models;
using SamStore.Order.Application.Validators;
using SamStore.Order.Domain.Interfaces;
using SamStore.Order.Domain.Vouchers;

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

        public async Task<RequestResponse<VoucherDTO>> GetByKey(string key)
        {
            Voucher voucher = await _voucherRepository.FirstOrDefaultAsync(x => x.Key == key);

            var validationResult = new VoucherStateValidator(Guid.NewGuid(), _voucherRepository)
                .Validate(voucher);

            if(!validationResult.IsValid)
                return new RequestResponse<VoucherDTO>(false, validationResult);

            VoucherDTO voucherDTO = _mapper.Map<VoucherDTO>(voucher);

            return new RequestResponse<VoucherDTO>(true, validationResult, voucherDTO);
        }
    }
}
