using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/cart-services")]
    public class CartServiceController : Controller
    {
        private readonly ICartServiceService _cartServiceService;
        public CartServiceController(ICartServiceService cartServiceService)
        {
            _cartServiceService = cartServiceService;
        }

        [HttpPost("create-service/{id:int}")]
        public async Task<ActionResult<bool>> CreateService(int id, [FromBody] CartServiceDTO service)
        {
            var isCreated = await _cartServiceService.CreateCartService(id, service);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Service could not be created");
        }

        [HttpGet("get-all/{id:int}")]
        public async Task<ActionResult<IEnumerable<CartServiceDTO>>> GetServicesByVehicleId(int id)
        {
            var result = await _cartServiceService.GetServicesByVehicleId(id);
            return Ok(result);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<List<CartServiceDTO>>> GetServiceById(int id)
        {
            var result = await _cartServiceService.GetService(id);
            return Ok(result);
        }
    }
}
