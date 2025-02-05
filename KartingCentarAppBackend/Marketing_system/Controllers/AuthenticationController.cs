using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly BL.Contracts.IService.IAuthenticationService _authenticationService;
        private readonly IClientService _clientService;

        public AuthenticationController(BL.Contracts.IService.IAuthenticationService authenticationService, IClientService clientService)
        {
            _authenticationService = authenticationService;
            _clientService = clientService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDTO>> RegisterClient([FromBody] ClientDTO client)
        {

            var isCreated= await _clientService.CreateClient(client);
            if (isCreated != null)
            {
                return Ok(isCreated);
            }
            return BadRequest("Service could not be created");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDTO>> Login([FromBody] CredentialsDTO credentialsDto)
        {

            if (credentialsDto == null) return BadRequest("Invalid credentials");
            var token = await _authenticationService.Login(credentialsDto.Email, credentialsDto.Password);
            if (token == null)
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(token);
        }
    }
}
