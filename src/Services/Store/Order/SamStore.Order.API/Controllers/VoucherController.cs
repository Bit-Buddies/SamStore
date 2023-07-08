using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamStore.Order.Application.Interfaces;
using SamStore.Order.Application.Models;
using SamStore.WebAPI.Core.API.Controllers;
using System.Net;

namespace SamStore.Order.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class VoucherController : MainController
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<VoucherDTO>> GetByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return NotFound();

            VoucherDTO voucher = await _voucherQueries.GetByKey(key);

            if (voucher == null)
                return NotFound();

            return CustomResponse(voucher);
        }
    }
}
