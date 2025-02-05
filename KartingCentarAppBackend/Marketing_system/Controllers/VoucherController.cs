using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/vouchers")]
    public class VoucherController : Controller
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateVoucher([FromBody] VoucherDTO voucher)
        {
            var isCreated = await _voucherService.CreateVoucher(voucher);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Voucher could not be created");
        }

        [HttpGet("check/{id:int}")]
        public async Task<ActionResult<VoucherDTO>> CheckVoucher(int id)
        {
            return await _voucherService.CheckVoucher(id);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<bool>> DeleteVoucher(int id)
        {
            var isDeleted = await _voucherService.DeleteVoucher(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest("Voucher could not be deleted");
        }
    }
}
