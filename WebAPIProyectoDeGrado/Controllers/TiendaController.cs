using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/tiendas")]
    public class TiendaController: ControllerBase
    {
        //djksjksd

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TiendaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("obtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<TiendaDTO>> obtenerPorEmailUsuario(string email)
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
    }
}
