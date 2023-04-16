using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.API.Services;
using SamStore.ShoppingCart.Application.Models;
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
        public async Task<ActionResult<ShoppingCartDTO>> GetCart()
        {
            var cart = await _shoppingCartService.GetCustomerCart();
            return CustomResponse(cart);
        }

        /// <summary>
        /// Update customer cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCart(ShoppingCartDTO cart)
        {
            await _shoppingCartService.UpdateCustomerCart(cart);
            return CustomResponse();
        }
    }
}
