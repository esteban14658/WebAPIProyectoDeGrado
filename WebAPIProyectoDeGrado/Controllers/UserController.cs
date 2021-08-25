using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await context.Users.Where(x => x.Role != "Admin").ToListAsync();
            return mapper.Map<List<UserDTO>>(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var exists = await context.Users.AnyAsync(x =>
                x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<UserDTO>(user);
        }

    }
}
