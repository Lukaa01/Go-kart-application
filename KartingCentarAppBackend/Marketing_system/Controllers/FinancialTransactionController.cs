using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/transactions")]
    public class FinancialTransactionController : Controller
    {
        private readonly IFinancialTransactionService _transactionService;
        public FinancialTransactionController(IFinancialTransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost("create/{id:int}")]
        public async Task<ActionResult<bool>> CreateFinancialTransaction(int id, [FromBody] FinancialTransactionDTO transaction)
        {
            var isCreated = await _transactionService.CreateFinancialTransaction(id, transaction);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Transaction could not be created");
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<FinancialTransactionDTO>>> GetFinancialTransactions()
        {
            var result = await _transactionService.GetFinancialTransactions();
            return Ok(result);
        }
    }
}
