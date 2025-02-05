using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/members")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IDebtService _debtService;
        public MemberController(IMemberService memberService, IDebtService debtService)
        {
            _memberService = memberService;
            _debtService = debtService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<MemberDTO>> CreateMember([FromBody] MemberDTO member)
        {
            var memberResult = await _memberService.CreateMember(member);
            return memberResult;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<MemberDTO>>> GetAllMembers()
        {
            var result = await _memberService.GetAllMembers();
            return Ok(result);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<MemberDTO>> GetMemberById(int id)
        {
            var result = await _memberService.GetMemberById(id);
            return Ok(result);
        }

        [HttpGet("get-for-instructor/{id:int}")]
        public async Task<ActionResult<MemberDTO>> GetMembersForInstructor(int id)
        {
            var result = await _memberService.GetMembersForInstructor(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<MemberDTO>> UpdateMember([FromBody] MemberDTO member)
        {
            var updatedClient = await _memberService.UpdateMember(member);
            if (updatedClient != null)
            {
                return Ok(updatedClient);
            }
            return BadRequest("Member could not be updated");
        }

        [HttpPut("block")]
        public async Task<ActionResult<bool>> BlockMember([FromBody] MemberDTO member)
        {
            var isBlocked = await _memberService.BlockMember(member);
            if (isBlocked)
            {
                return Ok(isBlocked);
            }
            return BadRequest("Member could not be blocked");
        }


        [HttpGet("get-all-debts/{id:int}")]
        public async Task<ActionResult<IEnumerable<DebtDTO>>> GetDebtsByMemberId(int id)
        {
            var result = await _debtService.GetDebtsByMemberId(id);
            return Ok(result);
        }

        [HttpPost("create-debt")]
        public async Task<ActionResult<bool>> CreateDebt([FromBody] DebtDTO debt)
        {
            var isCreated = await _debtService.CreateDebt(debt);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Debt could not be created");
        }

        [HttpPut("update-debt")]
        public async Task<ActionResult<bool>> UpdateDebt([FromBody] DebtDTO debt)
        {
            var isDeleted = await _debtService.UpdateDebt(debt);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest("Debt could not be deleted");
        }
    }
}
