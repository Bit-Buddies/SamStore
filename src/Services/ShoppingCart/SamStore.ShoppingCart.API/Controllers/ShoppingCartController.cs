using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Controllers;
using SamStore.WebAPI.Core.User;

namespace SamStore.ShoppingCart.API.Controllers
{
    [Route("api/cart")]
    public class ShoppingCartController : MainController
    {
        private readonly ShoppingCartContext _context;
        private readonly IContextUser _contextUser;

        public ShoppingCartController(ShoppingCartContext context, IContextUser contextUser)
        {
            _context = context;
            _contextUser = contextUser;
        }

        [HttpGet]
        public async Task<ActionResult<Cart>> GetCartCostumer()
        {
            var cart = await GetCart() ?? new Cart();
            return CustomResponse(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(CartItem item)
        {
            var cart = await GetCart();

            if (cart == null)
            {
                ManipulateNonExistingCart(item);
            }
            else
            {
                ManipulateExistingCart(cart, item);
            }

            if (!OperationIsValid())
                return CustomResponse();

            var result = await _context.SaveChangesAsync();

            if (result <= 0) 
                AddError("An error has ocourred while attempt persist the data in Database");

            return CustomResponse();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateItem(Guid productId, CartItem item)
        {
            return CustomResponse();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteItem(Guid productId)
        {
            return CustomResponse();
        }

        private async Task<Cart> GetCart()
        {
            return await _context.Carts
                .Include(s => s.Items)
                .FirstOrDefaultAsync(c => c.CostumerId == _contextUser.GetUserId());
        }

        private void ManipulateNonExistingCart(CartItem item)
        {
            Cart cart = new Cart(_contextUser.GetUserId());
            
            cart.AddItem(item);

            _context.Carts.Add(cart);
        }

        private void ManipulateExistingCart(Cart cart, CartItem item)
        {
            bool hasItem = cart.ItemAlreadyExists(item);

            cart.AddItem(item);

            if (hasItem)
            {
                _context.CartItems.Update(cart.GetItemByProductId(item.ProductId));
            }
            else
            {
                _context.CartItems.Add(item);
            }

            _context.Carts.Update(cart);
        }
    }
}
