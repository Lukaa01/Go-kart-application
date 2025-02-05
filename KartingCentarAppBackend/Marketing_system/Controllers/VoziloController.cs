using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Marketing_system.DA.Contracts.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Marketing_system.Controllers
{
    [Route("api/vehicle")]
    public class VoziloController : Controller
    {
        private readonly IVoziloService voziloService;

        public VoziloController(IVoziloService voziloService)
        {
            this.voziloService = voziloService;
        }
        
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<VoziloDTO>>> GetAllVehicles()
        {
            var rez = await voziloService.GetAllVehicles();
            return Ok(rez);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<CartServiceDTO>> GetVehicleById(int id)
        {
            var result = await voziloService.GetVehicleById(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<VoziloDTO>> CreateVehicle([FromBody] VoziloDTO vozilo)
        {
            var result = await voziloService.CreateVehicle(vozilo);
            return Ok(result);
        }

    }
}
