using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.API.Services;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Controllers;
using SamStore.WebAPI.Core.User;

namespace SamStore.ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : MainController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// Get customer cart by context user identity
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Cart>> GetCart()
        {
            return CustomResponse(await _shoppingCartService.GetCustomerCart());
        }

        /// <summary>
        /// Add a cart item into the customer context cart
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItem item)
        {
            await _shoppingCartService.AddCartItem(item);
            return CustomResponse();
        }

        /// <summary>
        /// Remove cart item from customer context cart 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            await _shoppingCartService.RemoveCartItem(productId);
            return CustomResponse();
        }

        /// <summary>
        /// Clear customer context cart
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            await _shoppingCartService.ClearCustomerCart();
            return CustomResponse();
        }
    }
}
