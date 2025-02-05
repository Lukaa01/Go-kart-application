using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/appointments")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<AppointmentDTO>> CreateAppointment([FromBody] AppointmentDTO appointment)
        {
            var isCreated = await _appointmentService.CreateAppointment(appointment);
            return isCreated;
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<bool>> DeleteAppointment(int id)
        {
            var isDeleted = await _appointmentService.DeleteAppointment(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest("Appointment could not be deleted");
        }
    }
}
