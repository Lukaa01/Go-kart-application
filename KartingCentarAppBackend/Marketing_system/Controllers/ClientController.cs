using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateClient([FromBody] ClientDTO client)
        {
            var isCreated = await _clientService.CreateClient(client);
            if (isCreated != null)
            {
                return Ok(isCreated);
            }
            return BadRequest("Client could not be created");
        }
        [HttpGet("get/{clientId:int}")]
        public async Task<ActionResult<ClientDTO>> GetClientById(int clientId)
        {
            var client = await _clientService.GetClientById(clientId);
            if (client != null)
            {
                return Ok(client);
            }
            return BadRequest("Client with that id does not exist.");
        }

        [HttpPut("update")]
        public async Task<ActionResult<ClientDTO>> UpdateClient([FromBody] ClientDTO client)
        {
            var updatedClient = await _clientService.UpdateClient(client);
            if (updatedClient != null)
            {
                return Ok(updatedClient);
            }
            return BadRequest("Client could not be blocked");
        }

        [HttpPut("add-penalties")]
        public async Task<ActionResult<ClientDTO>> AddPenalties([FromBody] ClientDTO client)
        {
            var updatedClient = await _clientService.AddPenalties(client);
            if (updatedClient != null)
            {
                return Ok(updatedClient);
            }
            return BadRequest("Client could not be blocked");
        }

        [HttpPut("block")]
        public async Task<ActionResult<bool>> BlockClient([FromBody] ClientDTO client)
        {
            var isBlocked = await _clientService.BlockClient(client);
            if (isBlocked)
            {
                return Ok(isBlocked);
            }
            return BadRequest("Client could not be blocked");
        }
    }
}
