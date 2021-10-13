using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using System.Net;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/residents")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsResident")]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService residentService;

        public ResidentController(IResidentService residentService)
        {
            this.residentService = residentService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDTO<ResidentDTO>>> Get(int page, int amount)
        {
            var residents = await residentService.GetAll(page, amount);
            return Ok(residents);
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<ActionResult<ResidentDTO>> GetUserById(int id)
        {
            var resident = await residentService.GetUserById(id);
            return Ok(resident);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<ResidentDTO>> GetUserByEmail(string email)
        {
            var resident = await residentService.GetUserByEmail(email);
            return Ok(resident);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateResidentDTO createResidentDTO)
        {
            var resident = await residentService.Insert(createResidentDTO);
            return Created("", resident);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ResidentDTO residentDTO, int id)
        {
            await residentService.Update(residentDTO, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //await residentService.Delete(id);
            await residentService.DeleteAll(id);
            return NoContent();
        }
    }
}
