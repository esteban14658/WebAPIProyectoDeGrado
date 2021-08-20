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
    [Route("api/residents")]
    public class ResidentController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ResidentController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResidentDTO>>> Get()
        {
            var residentes = await context.Residentes.Include(x => x.User).Include(x =>
                x.AddressList).ToListAsync();
            return mapper.Map<List<ResidentDTO>>(residentes);
        }

        [HttpGet("ObtenerPorIdlUsuario/{id:int}")]
        public async Task<ActionResult<ResidentDTO>> ObtenerPorIdlUsuario(int id)
        {
            var existe = await context.Residentes.AnyAsync(x =>
                x.User.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var residente = await context.Residentes.Include(x => x.User).Include(x =>
                x.AddressList).FirstOrDefaultAsync(x => x.User.Id == id);

            return mapper.Map<ResidentDTO>(residente);
        }

        [HttpGet("ObtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<ResidentDTO>> ObtenerPorEmailUsuario(string email)
        {
            var existe = await context.Residentes.AnyAsync(x =>
                x.User.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var residente = await context.Residentes.Include(x => x.User).Include(x =>
                x.AddressList).FirstOrDefaultAsync(x => x.User.Email == email);

            return mapper.Map<ResidentDTO>(residente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateResidentDTO residenteCreacionDTO)
        {
            var existeElUsuario = await context.Usuarios.AnyAsync(x => x.Email == residenteCreacionDTO.User.Email);

            if (existeElUsuario)
            {
                return BadRequest($"Ya existe un reciclador con el email: {residenteCreacionDTO.User.Email}");
            }

            var residente = mapper.Map<Resident>(residenteCreacionDTO);

            context.Add(residente);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
