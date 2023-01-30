using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.WebAPI.Core.API.Controllers;

namespace SamStore.Costumer.API.Controllers
{
    [Route("api/costumer")]
    [Authorize]
    public class CostumerController : MainController
    {
        
    }
}
