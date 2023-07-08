using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.Order.Application.Models;
using SamStore.WebAPI.Core.API.Controllers;

namespace SamStore.Order.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class VoucherController : MainController
    {
        [HttpGet("{key}")]
        public ActionResult<VoucherDTO> GetByKey(string key)
        {

        }
    }
}
