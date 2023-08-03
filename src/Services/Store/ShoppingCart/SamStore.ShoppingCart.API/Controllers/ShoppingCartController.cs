using EasyNetQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.API.Services;
using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Controllers;
using SamStore.WebAPI.Core.Context;
using System.Net;

namespace SamStore.ShoppingCart.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ShoppingCartController : CustomController
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
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCart(ShoppingCartDTO cart)
        {
            await _shoppingCartService.UpdateCustomerCart(cart);
            return CustomResponse();
        }
    }
}
