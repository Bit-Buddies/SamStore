using Microsoft.AspNetCore.Mvc;
using SamStore.WebAPI.Core.API.Controllers;

namespace SamStore.BFF.Orders.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomerCart()
        {
            return CustomResponse();
        }

        [HttpGet("items/quantity")]
        public async Task<IActionResult> GetCustomerCartItemsQuantity()
        {
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerCart()
        {
            return CustomResponse();
        }

        [HttpDelete]
        public async Task<IActionResult> ClearCustomerCart()
        {
            return CustomResponse();
        }
    }
}
