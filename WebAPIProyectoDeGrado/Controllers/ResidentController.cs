using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/residents")]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService residentService;

        public ResidentController(IResidentService residentService)
        {
            this.residentService = residentService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDto<ResidentDto>>> Get(int page, int amount)
        {
            var residents = await residentService.GetAll(page, amount);
            return Ok(residents);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ResidentDto>> GetById(int id)
        {
            var resident = await residentService.GetById(id);
            return Ok(resident);
        }

        [HttpGet("GetByUserId/{id:int}")]
        public async Task<ActionResult<ResidentDto>> GetUserById(int id)
        {
            var resident = await residentService.GetUserById(id);
            return Ok(resident);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<ResidentDto>> GetUserByEmail(string email)
        {
            var resident = await residentService.GetUserByEmail(email);
            return Ok(resident);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateResidentDto createResidentDTO)
        {
            var resident = await residentService.Insert(createResidentDTO);
            return Created("", resident);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ResidentDto residentDTO, int id)
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
