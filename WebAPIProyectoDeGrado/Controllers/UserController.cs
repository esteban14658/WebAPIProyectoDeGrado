using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        { 
            var users = await context.UsersApp.Where(x => x.Role != "Admin").ToListAsync();
            return mapper.Map<List<UserDto>>(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var exists = await context.UsersApp.AnyAsync(x =>
                x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            var user = await context.UsersApp.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<UserDto>(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateUserDto createUserDTO, int id)
        {
            var exist = await context.UsersApp.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            var user = mapper.Map<User>(createUserDTO);
            user.Id = id;

            context.Update(user);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.UsersApp.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new User() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("VerifyIsPresent/{email}")]
        public async Task<ActionResult> VerifyIsPresent(string email)
        {
            var isPresent = await context.UsersApp.FirstOrDefaultAsync(x => x.Email.Equals(email));
            if (isPresent == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("VerifyState/{email}")]
        public async Task<ActionResult> VerifyState(string email)
        {
            var isPresent = await context.UsersApp.FirstOrDefaultAsync(x => x.Email.Equals(email));
            if (isPresent == null)
            {
                return NotFound();
            }
            if (!isPresent.State)
            {
                return Unauthorized();
            }
            return Ok();
        }

        [HttpPut("Activate/{email}/{state}")]
        public async Task<ActionResult> Activate(string email, string state)
        {
            var isPresent = await context.UsersApp.AnyAsync(x => x.Email.Equals(email));
            if (!isPresent)
            {
                return NotFound();
            }
            var query = from u in context.UsersApp
                        where u.Email == email
                        select u;
            foreach (var item in query)
            {
                if (state.Equals("true"))
                {
                    item.State = true;
                } else
                {
                    item.State = false;
                }
            }
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}