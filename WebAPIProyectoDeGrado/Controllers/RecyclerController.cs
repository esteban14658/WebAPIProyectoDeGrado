using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/recyclers")]
    //   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsRecycler")]
    public class RecyclerController : ControllerBase
    {
        private readonly IRecyclerService recyclerService;

        public RecyclerController(IRecyclerService recyclerService)
        {
            this.recyclerService = recyclerService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDto<RecyclerDto>>> Get(int page, int amount)
        {
            var recyclers = await recyclerService.GetAll(page, amount);
            return recyclers;
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<RecyclerDto>> GetById(int id)
        {
            var recycler = await recyclerService.GetById(id);
            return recycler;
        }

        [HttpGet("GetUserById/{userId:int}")]
        public async Task<ActionResult<RecyclerDto>> GetUserById(int userId)
        {
            var recycler = await recyclerService.GetUserById(userId);
            return Ok(recycler);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<RecyclerDto>> GetUserByEmail(string email)
        {
            var recycler = await recyclerService.GetUserByEmail(email);
            return Ok(recycler);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateRecyclerDto recyclerDTO)
        {
            var recycler = await recyclerService.Insert(recyclerDTO);
            return Created("", recycler);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(RecyclerDto recyclerDTO, int id)
        {
            await recyclerService.Update(recyclerDTO, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await recyclerService.Delete(id);
            return NoContent();
        }
    }
}