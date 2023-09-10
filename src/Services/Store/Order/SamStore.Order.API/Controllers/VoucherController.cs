using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.Core.CQRS;
using SamStore.Order.Application.Interfaces;
using SamStore.Order.Application.Models;
using SamStore.WebAPI.Core.API.Controllers;
using System.Net;

namespace SamStore.Order.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class VoucherController : CustomController
    {
        private readonly IVoucherQueries _voucherQueries;

        public VoucherController(IVoucherQueries voucherQueries)
        {
            _voucherQueries = voucherQueries;
        }

        /// <summary>
        /// Get voucher by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("{key}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<VoucherDTO>> GetByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                AddError("Please, type a correct key.");
                return CustomResponse();
            }

            RequestResponse<VoucherDTO> result = 
                await _voucherQueries.GetByKey(key);

            if (result.Success == false)
                return CustomResponse(result.ValidationResult);

            return CustomResponse(result.Response);
        }
    }
}
