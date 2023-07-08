using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.WebAPI.Core.API.Controllers;

namespace SamStore.Costumer.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CostumerController : MainController
    {
        
    }
}
