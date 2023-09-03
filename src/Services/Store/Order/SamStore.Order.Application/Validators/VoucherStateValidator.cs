using FluentValidation;
using FluentValidation.Results;
using SamStore.Order.Domain.Interfaces;
using SamStore.Order.Domain.Vouchers;
using SamStore.Order.Domain.Vouchers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Application.Validators
{
    public class VoucherStateValidator : AbstractValidator<Voucher>
    {
        public VoucherStateValidator(Guid customerId, IVoucherRepository voucherRepository) 
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Voucher not found");

            RuleFor(x =>
                x.VoucherType == VoucherTypeEnum.Expire &&
                x.ExpireAt < DateTime.Now)
                    .Must(x => false)
                    .WithMessage("Voucher expired");

            RuleFor(x =>
                x.VoucherType == VoucherTypeEnum.Default &&
                x.Quantity <= x.QuantityUsed)
                    .Must(x => false)
                    .WithMessage("Voucher is sold out");

            RuleFor(voucher => voucher)
                .MustAsync(async (voucher, cancellationToken) =>
                {
                    if (voucher.VoucherType == VoucherTypeEnum.OncePerAccount)
                        return true;

                    return true;
                })
                .WithMessage("Already used");
        }
    }
}
