using FluentValidation;
using SamStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Domain.ShoppingCarts
{
    public class CartItem : Entity
    {
        public Guid ProductId { get; private set; }
        public Guid CartId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string? Image { get; private set; }
        public virtual Cart Cart { get; set; }

        protected CartItem() { }
        public CartItem(Guid productId, Guid cartId, string name, int quantity, decimal price, string image)
        {
            ProductId = productId;
            CartId = cartId;
            Name = name;
            Quantity = quantity;
            Price = price;
            Image = image;
        }

        public void LinkCart(Guid cartId)
        {
            CartId = cartId;
        }

        public decimal CalcPrice()
        {
            return Price * Quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override bool IsValid()
        {
            return new CartItemValidator().Validate(this).IsValid;
        }

        public class CartItemValidator : AbstractValidator<CartItem>
        {
            public CartItemValidator()
            {
                RuleFor(c => c.ProductId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Invalid productId");

                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("Invalid product name");

                RuleFor(c => c.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Quantity most be greater than 0");

                RuleFor(c => c.Price)
                    .GreaterThan(0)
                    .WithMessage("Price most be greater than 0");
            }
        }
    }
}
