using Microsoft.AspNetCore.Mvc;
using SamStore.BFF.Orders.Interfaces;
using SamStore.WebAPI.Core.API.Controllers;

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

        [HttpGet]
        public async Task<IActionResult> GetCustomerCart()
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
