using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Bussiness.Services;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountService;

        public AccountsController(IAccountsService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> Login(UserCredentials userCredentials)
        {
            var result = await _accountService.Login(userCredentials);
            return Ok(result);
        }

        [HttpPost("DoAdmin")]
        [AllowAnonymous]
        public async Task<ActionResult> DoAdmin(EditAdminDTO editAdminDTO)
        {
            await _accountService.DoAdmin(editAdminDTO);
            return NoContent();
        }

        [HttpPost("ConfirmEmail/{email}/{code}")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string email, string code)
        {
            await _accountService.ConfirmEmail(email, code);
            return NoContent();
        }

        [HttpPost("SendPasswordChangeCode/{email}")]
        [AllowAnonymous]
        public async Task<ActionResult> SendPasswordChangeCode(string email)
        {
            await _accountService.SendPasswordChangeCode(email);
            return NoContent();
        }

        [HttpPost("ChangePassword/{code}")]
        public async Task<ActionResult> ChangePassword([FromBody] CreateUserDTO createUser, string code)
        {
            await _accountService.ChangePassword(createUser, code);
            return NoContent();
        }
    }
}
