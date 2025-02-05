using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/competitions")]
    public class CompetitionController : Controller
    {
        private readonly ICompetitionService _competitionService;
        private readonly ISuccessService _successService;
        public CompetitionController(ICompetitionService competitionService, ISuccessService successService)
        {
            _competitionService = competitionService;
            _successService = successService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateCompetition([FromBody] CompetitionDTO competition)
        {
            var isCreated = await _competitionService.CreateCompetition(competition);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Competition could not be created");
        }

        [HttpPost("add-success/{memberId:int}/{competitionId:int}")]
        public async Task<ActionResult<bool>> AddSuccess(int memberId, int competitionId, [FromBody] List<SuccessDTO> success)
        {
            var isCreated = await _successService.AddSuccess(memberId, competitionId, success);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Competition could not be created");
        }

        [HttpGet("get-all-future")]
        public async Task<ActionResult<IEnumerable<CompetitionDTO>>> GetAllFutureCompetitions()
        {
            var result = await _competitionService.GetAllFutureCompetitions();
            return Ok(result);
        }

        [HttpGet("get-all-past")]
        public async Task<ActionResult<IEnumerable<CompetitionDTO>>> GetAllPastCompetitions()
        {
            var result = await _competitionService.GetAllPastCompetitions();
            return Ok(result);
        }
    }
}
