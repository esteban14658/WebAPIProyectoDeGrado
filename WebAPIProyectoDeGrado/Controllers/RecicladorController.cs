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

        [HttpGet]
        public async Task<ActionResult<List<RecyclerDTO>>> Get()
        {
            var recicladores = await context.Recicladores.Include(x => x.Usuario).ToListAsync();
            return mapper.Map<List<RecyclerDTO>>(recicladores);
        }

        [HttpGet("ObtenerPorIdUsuario/{idUsuario:int}")]
        public async Task<ActionResult<RecyclerDTO>> ObtenerPorIdUsuario(int idUsuario)
        {
            var existe = await context.Recicladores.AnyAsync(x =>
                x.Usuario.Id == idUsuario);

            if (!existe)
            {
                return NotFound();
            }
            
            var reciclador = await context.Recicladores.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Usuario.Id == idUsuario);
            return mapper.Map<RecyclerDTO>(reciclador);
        }

        [HttpGet("ObtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<RecyclerDTO>> ObtenerPorEmailUsuario(string email)
        {
            var existe = await context.Recicladores.AnyAsync(x =>
                x.Usuario.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var reciclador = await context.Recicladores.Include(x => x.Usuario).FirstOrDefaultAsync(x => 
                x.Usuario.Email == email);
            return mapper.Map<RecyclerDTO>(reciclador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRecyclerDTO recicladorCreacionDTO)
        {
            var existeElUsuario = await context.Usuarios.AnyAsync(x => x.Email == recicladorCreacionDTO.Usuario.Email);

            if (existeElUsuario)
            {
                return BadRequest($"Ya existe un reciclador con el email: {recicladorCreacionDTO.Usuario.Email}");
            }

            var reciclador = mapper.Map<Recycler>(recicladorCreacionDTO);

            context.Add(reciclador);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Recycler reciclador, int id)
        {
            if (reciclador.Id != id)
            {
                return BadRequest("El id no coincide");
            }

            var existe = await context.Recicladores.AnyAsync(x =>
                x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(reciclador);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}