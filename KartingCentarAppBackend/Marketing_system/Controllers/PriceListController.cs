using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/pricelist")]
    public class PriceListController : Controller
    {
        private readonly IPriceListService _priceListService;
        public PriceListController(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreatePriceList([FromBody] PriceListItemDTO item)
        {
            var isCreated = await _priceListService.CreatePriceListItem(item);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Item could not be created");
        }

        [HttpGet("all-items")]
        public async Task<ActionResult<IEnumerable<PriceListItemDTO>>> GetAllItems()
        {
            var result = await _priceListService.GetAllItems();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdatePriceListItem([FromBody] PriceListItemDTO item)
        {
            var isBlocked = await _priceListService.UpdatePriceListItem(item);
            if (isBlocked)
            {
                return Ok(isBlocked);
            }
            return BadRequest("Item could not be updated");
        }
    }
}
