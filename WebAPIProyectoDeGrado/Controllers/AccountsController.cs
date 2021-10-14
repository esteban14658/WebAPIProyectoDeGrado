using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Bussiness.Services;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

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
        public async Task<ActionResult<AuthenticationResponse>> Login(UserCredentials userCredentials)
        {
            var result = await _accountService.Login(userCredentials);
            return Ok(result);
        }

        [HttpPost("DoAdmin")]
        public async Task<ActionResult> DoAdmin(EditAdminDTO editAdminDTO)
        {
            await _accountService.DoAdmin(editAdminDTO);
            return NoContent();
        }
    }
}
