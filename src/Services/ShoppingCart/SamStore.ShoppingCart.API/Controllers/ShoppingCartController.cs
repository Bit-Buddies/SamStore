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
    [Route("api/cart")]
    public class ShoppingCartController : MainController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<ActionResult<Cart>> GetCart()
        {
            return CustomResponse(await _shoppingCartService.GetCustomerCart());
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItem item)
        {
            await _shoppingCartService.AddCartItem(item);
            return CustomResponse();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            await _shoppingCartService.RemoveCartItem(productId);
            return CustomResponse();
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            await _shoppingCartService.ClearCustomerCart();
            return CustomResponse();
        }
    }
}
