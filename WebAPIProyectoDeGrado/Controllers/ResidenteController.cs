using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/residentes")]
    public class ResidenteController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ResidenteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("obtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<ResidenteDTO>> obtenerPorEmailUsuario(string email)
        {
            var existe = await context.Residentes.AnyAsync(x =>
                x.Usuario.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var residente = await context.Residentes.Include(x => x.Usuario).Include(x => 
                x.ListaDirecciones).FirstOrDefaultAsync(x => x.Usuario.Email == email);

            return mapper.Map<ResidenteDTO>(residente);
        }
    }
}
