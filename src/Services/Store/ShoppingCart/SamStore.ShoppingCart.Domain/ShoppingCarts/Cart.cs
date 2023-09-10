using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Storage;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.ShoppingCart.Domain.Vouchers;
using SamStore.ShoppingCart.Domain.Vouchers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Domain.ShoppingCarts
{
    public class Cart : Entity, IAggregateRoot
    {
        public Guid CostumerId { get; private set; }
        public Voucher Voucher { get; private set; }
        public virtual ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

        public Cart() { }
        public Cart(Guid costumerId)
        {
            CostumerId = costumerId;
        }

        public bool ItemAlreadyExists(CartItem item)
        {
            return Items.Any(i => i.ProductId == item.ProductId);
        }

        public CartItem GetItemByProductId(Guid productId)
        {
            return Items.FirstOrDefault(i => i.ProductId == productId);
        }

        public void ApplyVoucher(Voucher voucher)
        {
            Voucher = voucher;
        }

        public void AddItem(CartItem item)
        {
            if (!item.IsValid())
                return;

            item.LinkCart(Id);
         
            if(ItemAlreadyExists(item)) 
            {
                CartItem oldItem = GetItemByProductId(item.ProductId);
                oldItem.SetQuantity(item.Quantity);
            }
            else
            {
                Items.Add(item);
            }
        }

        public void UpdateItem(CartItem item)
        {
            if (!item.IsValid())
                return;

            item.LinkCart(Id);

            var oldItem = GetItemByProductId(item.ProductId);

            Items.Remove(oldItem);
            Items.Add(item);
        }

        public void UpdateQuantity(Guid productId, int quantity)
        {
            var item = GetItemByProductId(productId);

            item.SetQuantity(quantity);

            if (item.Quantity <= 0)
                Items.Remove(item);
        }

        public void RemoveItem(Guid productId)
        {
            var itemToRemove= Items
                .FirstOrDefault(i => i.ProductId == productId);

            if (itemToRemove == null)
                return;

            Items.Remove(itemToRemove);
        }

        public decimal GetTotal()
        {
            var total = Items.Sum(item => item.GetTotal());
            
            if(Voucher != null)
            {
                switch (Voucher.DiscountType)
                {
                    case VoucherDiscountTypeEnum.Percentual:
                        total -= total * (Voucher.Discount!.Value / 100);
                        break;
                    case VoucherDiscountTypeEnum.Value:
                        total -= Voucher.Discount!.Value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return total;
        } 

        public void Clear()
        {
            if (!Items.Any())
                return;

            Items.Clear();
        }

        public override bool IsValid()
        {
            List<ValidationFailure> errors = Items
                .SelectMany(i => new CartItem.CartItemValidator().Validate(i).Errors).ToList();
            
            errors.AddRange(new CartValidator()
                .Validate(this).Errors);

            ValidationResult validationResult = new ValidationResult(errors);

            return validationResult.IsValid;
        }

        public class CartValidator: AbstractValidator<Cart>
        {
            public CartValidator()
            {
                RuleFor(c => c.CostumerId)
                    .NotEqual(Guid.Empty);
            }
        }
    }
}
