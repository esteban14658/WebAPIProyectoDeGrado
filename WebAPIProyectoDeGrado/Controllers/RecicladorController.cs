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
    [Route("api/recicladores")]
    public class RecicladorController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RecicladorController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("obtenerPorIdUsuario/{idUsuario:int}")]
        public async Task<ActionResult<RecicladorDTO>> obtenerPorIdUsuario(int idUsuario)
        {
            var existe = await context.Recicladores.AnyAsync(x =>
                x.Usuario.Id == idUsuario);

            if (!existe)
            {
                return NotFound();
            }

            var reciclador = await context.Recicladores.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Usuario.Id == idUsuario);
            return mapper.Map<RecicladorDTO>(reciclador);
        }

        [HttpGet("obtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<RecicladorDTO>> obtenerPorEmailUsuario(string email)
        {
            var existe = await context.Recicladores.AnyAsync(x =>
                x.Usuario.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var reciclador = await context.Recicladores.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Usuario.Email == email);
            return mapper.Map<RecicladorDTO>(reciclador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecicladorCreacionDTO recicladorCreacionDTO)
        {
            var existeElUsuario = await context.Usuarios.AnyAsync(x => x.Email == recicladorCreacionDTO.Usuario.Email);

            if (existeElUsuario)
            {
                return BadRequest($"Ya existe un reciclador con el email: {recicladorCreacionDTO.Usuario.Email}");
            }

            var reciclador = mapper.Map<Reciclador>(recicladorCreacionDTO);

            context.Add(reciclador);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
