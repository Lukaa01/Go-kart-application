using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/sponsors")]
    public class SponsorController : Controller
    {
        private readonly ISponsorService _sponsorService;
        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateSponsor([FromBody] SponsorDTO sponsor)
        {
            var isCreated = await _sponsorService.CreateSponsor(sponsor);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Sponsor could not be created");
        }

        [HttpPost("add-funds")]
        public async Task<ActionResult<bool>> AddFunds([FromBody] FundDTO fund)
        {
            var isAdded = await _sponsorService.AddFunds(fund);
            if (isAdded)
            {
                return Ok(isAdded);
            }
            return BadRequest("Sponsor could not be added");
        }
    }
}
