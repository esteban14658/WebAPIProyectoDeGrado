using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUserService userService;


        public UserController(ApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            //var us = await userService.GetAll();
            var users = await context.UsersApp.Where(x => x.Role != "Admin").ToListAsync();
            return mapper.Map<List<UserDTO>>(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var exists = await context.UsersApp.AnyAsync(x =>
                x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            var user = await context.UsersApp.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<UserDTO>(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateUserDTO createUserDTO, int id)
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

    }
}
