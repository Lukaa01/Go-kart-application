using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/reservations")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ITrainingService _trainingService;
        public ReservationController(IReservationService reservationService, ITrainingService trainingService)
        {
            this._reservationService = reservationService;
            _trainingService = trainingService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateReservation([FromBody] ReservationDTO reservation)
        {
            var isCreated = await _reservationService.CreateReservation(reservation);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Reservation could not be created");
        }

        [HttpPatch("pay/{id:int}")]
        public async Task<ActionResult<ReservationDTO>> PayReservation(int id)
        {
            var result = await _reservationService.PayReservation(id);
            if (result == null)
            {
                return BadRequest("Reservation could not be updated");
            }
            return Ok(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<bool>> DeleteReservation(int id)
        {
            var isDeleted = await _reservationService.DeleteReservation(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest("Training could not be deleted");
        }

        [HttpGet("all-reservations/{id:int}")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAllReservations(int id)
        {
            var result = await _reservationService.GetAllReservationsForTrack(id);
            return Ok(result);
        }

        [HttpPost("create-training/{id:int}")]
        public async Task<ActionResult<TrainingDTO>> CreateTraining(int id, [FromBody] List<TrainingDTO> trainings)
        {
            var list = await _trainingService.CreateTraining(id, trainings);
            return Ok(list);
        }

        [HttpPost("add-members/{trainingId:int}")]
        public async Task<ActionResult<bool>> AddMembersToTraining(int trainingId, [FromBody] List<MemberDTO> members)
        {
            var isAdded = await _trainingService.AddMembersToTraining(trainingId, members);
            if (isAdded)
            {
                return Ok(isAdded);
            }
            return BadRequest("Members are not added to training");
        }

        [HttpGet("all-trainings/{id:int}")]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetAllTrainings(int id)
        {
            var result = await _trainingService.GetAllTrainingsByTrack(id);
            return Ok(result);
        }

        [HttpGet("get-trainings-for-member/{memberId:int}")]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetTrainingsByMemberId(int memberId)
        {
            var result = await _trainingService.GetTrainingsByMemberId(memberId);
            return Ok(result);
        }

        [HttpGet("get-trainings-instructor/{instructorId:int}")]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetTrainingsForInstructor(int instructorId)
        {
            var result = await _trainingService.GetTrainingsForInstructor(instructorId);
            return Ok(result);
        }

        [HttpDelete("delete-training/{id:int}")]
        public async Task<ActionResult<bool>> DeleteTraining(int id)
        {
            var isDeleted = await _trainingService.DeleteTraining(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest("Training could not be deleted");
        }
    }
}
