
using Microsoft.AspNetCore.Mvc;
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
        private readonly IOrderService _orderService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        /// <summary>
        /// Get customer cart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ShoppingCartDTO>> GetCart()
        {
            var cart = await _shoppingCartService.GetCustomerCartAsync();

            if (cart == null)
            {
                AddError("Couldn't take the shopping cart");
                return CustomResponse();
            }

            return CustomResponse(cart);
        }

        /// <summary>
        /// Update customer cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCart(ShoppingCartDTO shoppingCart)
        {
            var result = await _shoppingCartService.UpdateCustomerCartAsync(shoppingCart);

            if(result == false)
            {
                AddError("Couldn't update shopping cart.");
                return CustomResponse(result);
            }

            return CustomResponse(result);     
        }

        /// <summary>
        /// Apply voucher into shopping cart
        /// </summary>
        /// <param name="voucherKey"></param>
        /// <returns></returns>
        [HttpPost("voucher")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApplyVoucher([FromBody] string voucherKey)
        {
            var voucher = await _orderService.GetVoucherByKey(voucherKey);

            if(voucher is null)
            {
                AddError("Voucher was not found or is invalid");
                return CustomResponse();
            }

            await _shoppingCartService.ApplyVoucher(voucher);

            return CustomResponse();
        }
    }
}
