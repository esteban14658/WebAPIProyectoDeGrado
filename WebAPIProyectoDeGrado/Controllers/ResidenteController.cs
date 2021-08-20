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

        [HttpGet]
        public async Task<ActionResult<List<ResidentDTO>>> Get()
        {
            var residentes = await context.Residentes.Include(x => x.Usuario).Include(x =>
                x.ListaDirecciones).ToListAsync();
            return mapper.Map<List<ResidentDTO>>(residentes);
        }

        [HttpGet("ObtenerPorIdlUsuario/{id:int}")]
        public async Task<ActionResult<ResidentDTO>> ObtenerPorIdlUsuario(int id)
        {
            var existe = await context.Residentes.AnyAsync(x =>
                x.Usuario.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var residente = await context.Residentes.Include(x => x.Usuario).Include(x =>
                x.ListaDirecciones).FirstOrDefaultAsync(x => x.Usuario.Id == id);

            return mapper.Map<ResidentDTO>(residente);
        }

        [HttpGet("ObtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<ResidentDTO>> ObtenerPorEmailUsuario(string email)
        {
            var existe = await context.Residentes.AnyAsync(x =>
                x.Usuario.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var residente = await context.Residentes.Include(x => x.Usuario).Include(x => 
                x.ListaDirecciones).FirstOrDefaultAsync(x => x.Usuario.Email == email);

            return mapper.Map<ResidentDTO>(residente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateResidentDTO residenteCreacionDTO)
        {
            var existeElUsuario = await context.Usuarios.AnyAsync(x => x.Email == residenteCreacionDTO.Usuario.Email);

            if (existeElUsuario)
            {
                return BadRequest($"Ya existe un reciclador con el email: {residenteCreacionDTO.Usuario.Email}");
            }

            var residente = mapper.Map<Residente>(residenteCreacionDTO);

            context.Add(residente);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
