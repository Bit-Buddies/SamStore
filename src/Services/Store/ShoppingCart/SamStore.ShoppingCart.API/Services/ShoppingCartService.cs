using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.Application.Extensions;
using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using SamStore.ShoppingCart.Domain.Vouchers;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.Context;

namespace SamStore.ShoppingCart.API.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextHandler _httpContextHandler;
        private readonly ShoppingCartContext _context;

        public ShoppingCartService(IHttpContextHandler httpContextHandler, ShoppingCartContext context)
        {
            _httpContextHandler = httpContextHandler;
            _context = context;
        }

        public async Task ApplyVoucher(VoucherDTO voucher)
        {
            Cart cart = await GetCart();
            Voucher newVoucher = new Voucher(
                voucher.Key, 
                voucher.Discount, 
                voucher.VoucherDiscountType);

            cart.ApplyVoucher(newVoucher);

            if (_context.Carts.Any(c => c.Id == cart.Id))
                _context.Carts.Update(cart);
            else
                _context.Carts.Add(cart);

            await CommitChanges();
        }

        public async Task<ShoppingCartDTO> GetCustomerCart()
        {
            var cart = await GetCart();
            return cart.ToDTO();
        }


        public async Task UpdateCustomerCart(ShoppingCartDTO cartDTO)
        {
            var existingCart = await _context.Carts
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == cartDTO.Id);

            if (existingCart != null)
            {
                foreach (CartItem? item in existingCart.Items.ToList())
                {
                    if (!cartDTO.Items.Any(i => i.ProductId == item?.ProductId))
                        _context.CartItems.Remove(item);
                }

                foreach (var item in cartDTO.Items)
                {
                    CartItem? existingItem = existingCart.Items.FirstOrDefault(i => i.ProductId == item?.ProductId);

                    if (existingItem != null && item.Quantity != existingItem.Quantity)
                    {
                        existingItem.SetQuantity(item.Quantity);

                        if (existingItem.Quantity <= 0)
                            _context.CartItems.Remove(existingItem);
                        else
                            _context.CartItems.Update(existingItem);
                    }
                    else if (existingItem == null)
                    {
                        var newItem = new CartItem(item.ProductId, existingCart.Id, item.Name, item.Quantity, item.Price, item.ImagePath!);
                        _context.CartItems.Add(newItem);
                    }
                }
            }
            else
            {
                var cart = new Cart(_httpContextHandler.GetUserId()) { Id = cartDTO.Id, };

                foreach (var item in cartDTO.Items)
                    cart.AddItem(new CartItem(item.ProductId, item.CartId, item.Name, item.Quantity, item.Price, item.ImagePath!));

                _context.Carts.Add(cart);
            }

            await CommitChanges();
        }

        private async Task<Cart> GetCart()
        {
            var userId = _httpContextHandler.GetUserId();

            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CostumerId.Equals(userId));

            cart ??= new Cart(userId);

            return cart;
        }

        private async Task<bool> CommitChanges()
        {
            return await _context.Commit();
        }
    }
}
