﻿using Microsoft.AspNetCore.Mvc;
using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.WebAPI.Core.API.Controllers;
using System.Net;

namespace SamStore.BFF.Orders.Controllers
{
    [Route("api/v1/[controller]")]
    public class ShoppingCartController : CustomController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// Get customer cart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDTO>> GetCart()
        {
            var cart = await _shoppingCartService.GetCustomerCartAsync();

            if (cart == null)
                return BadRequest("Couldn't take the shopping cart");

            return CustomResponse(cart);
        }

        /// <summary>
        /// Update customer cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCart(ShoppingCartDTO shoppingCart)
        {
            var result = await _shoppingCartService.UpdateCustomerCartAsync(shoppingCart);

            return CustomResponse(result);     
        }
    }
}
