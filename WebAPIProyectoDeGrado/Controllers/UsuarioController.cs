using AutoMapper;
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
    [Route("api/usuarios")]
    public class UsuarioController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuarioController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] 
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x =>
                x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var autor = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<UsuarioDTO>(autor);
        }

    }
}
