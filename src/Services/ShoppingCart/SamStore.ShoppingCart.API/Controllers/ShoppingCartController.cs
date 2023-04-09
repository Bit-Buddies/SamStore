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
    }
}
