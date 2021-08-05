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
    [Route("api/tiendas")]
    public class TiendaController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TiendaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TiendaDTO>>> Get()
        {
            var tiendas = await context.Tiendas.Include(x => 
                x.Usuario).Include(x => x.Direccion).ToListAsync();
            return mapper.Map<List<TiendaDTO>>(tiendas);
        }

        [HttpGet("ObtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<TiendaDTO>> ObtenerPorEmailUsuario(string email)
        {
            var existe = await context.Tiendas.AnyAsync(x =>
                x.Usuario.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var tienda = await context.Tiendas.Include(x => x.Usuario).Include(x =>
                x.Direccion).FirstOrDefaultAsync(x => x.Usuario.Email == email);

            return mapper.Map<TiendaDTO>(tienda);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TiendaCreacionDTO tiendaCreacionDTO)
        {
            var existeElUsuario = await context.Usuarios.AnyAsync(x => x.Email == tiendaCreacionDTO.Usuario.Email);

            if (existeElUsuario)
            {
                return BadRequest($"Ya existe una tienda con el email: {tiendaCreacionDTO.Usuario.Email}");
            }

            var tienda = mapper.Map<Tienda>(tiendaCreacionDTO);

            context.Add(tienda);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
