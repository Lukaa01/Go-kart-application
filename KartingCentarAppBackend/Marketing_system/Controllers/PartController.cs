using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/parts")]
    public class PartController : Controller
    {
        private readonly IPartService _partService;
        private readonly IPartItemService _partItemService;
        private readonly IPartRequestService _partRequestService;
        public PartController(IPartService partService, IPartItemService partItemService, IPartRequestService partRequestService)
        {
            _partService = partService;
            _partItemService = partItemService;
            _partRequestService = partRequestService;
        }

        [HttpPost("create-part")]
        public async Task<ActionResult<PartDTO>> CreatePart([FromBody] PartDTO part)
        {
            var createdPart = await _partService.CreatePart(part);
            return createdPart;
        }

        [HttpPost("create-part-item")]
        public async Task<ActionResult<bool>> CreatePartItem([FromBody] PartItemDTO part)
        {
            var isCreated = await _partItemService.CreatePartItem(part);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Part item could not be created");
        }

        [HttpDelete("delete-item/{id:int}")]
        public async Task<ActionResult<bool>> DeletePartItem(int id)
        {
            var isDeleted = await _partItemService.DeletePartItem(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest("Part could not be deleted");
        }

        [HttpPut("update-part")]
        public async Task<ActionResult<bool>> UpdatePart([FromBody] PartDTO part)
        {
            var isUpdated = await _partService.UpdatePart(part);
            if (isUpdated != null)
            {
                return Ok(isUpdated);
            }
            return BadRequest("Part could not be updated");
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<PartDTO>>> GetAllParts()
        {
            var result = await _partService.GetAllParts();
            return Ok(result);
        }

        [HttpGet("get-all-part-requests")]
        public async Task<ActionResult<List<PartRequestDTO>>> GetAllPartRequests()
        {
            var result = await _partRequestService.GetAllPartRequests();
            return Ok(result);
        }

        [HttpGet("get-all-admin")]
        public async Task<ActionResult<List<PartRequestDTO>>> GetAllPartRequestsForAdmin()
        {
            var result = await _partRequestService.GetAllPartRequestsForAdmin();
            return Ok(result);
        }

        [HttpPost("create-part-request")]
        public async Task<ActionResult<PartRequestDTO>> CreatePartRequest([FromBody] PartRequestDTO part)
        {
            var isCreated = await _partRequestService.CreatePartRequest(part);
            return isCreated;
        }

        [HttpPut("update-part-request")]
        public async Task<ActionResult<bool>> UpdatePartRequest([FromBody] PartRequestDTO req)
        {
            var isUpdated = await _partRequestService.UpdatePartRequest(req);
            if (isUpdated != null)
            {
                return Ok(isUpdated);
            }
            return BadRequest("Part request could not be updated");
        }
    }
}
