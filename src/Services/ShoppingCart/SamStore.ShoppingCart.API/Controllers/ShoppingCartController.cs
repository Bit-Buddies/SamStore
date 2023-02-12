using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using SamStore.WebAPI.Core.API.Controllers;

namespace SamStore.ShoppingCart.API.Controllers
{
    [Route("api/cart")]
    public class ShoppingCartController : MainController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCartCostumer>> GetCartCostumer()
        {
            return CustomResponse();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ShoppingCartItem item)
        {
            return CustomResponse();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateItem(Guid productId, ShoppingCartItem item)
        {
            return CustomResponse();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteItem(Guid productId)
        {
            return CustomResponse();
        }
    }
}
