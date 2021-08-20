﻿using AutoMapper;
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
    [Route("api/shops")]
    public class ShopController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ShopController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShopDTO>>> Get()
        {
            var tiendas = await context.Tiendas.Include(x => 
                x.User).Include(x => x.Address).ToListAsync();
            return mapper.Map<List<ShopDTO>>(tiendas);
        }

        [HttpGet("ObtenerPorIdUsuario/{id:int}")]
        public async Task<ActionResult<ShopDTO>> ObtenerPorIdUsuario(int id)
        {
            var existe = await context.Tiendas.AnyAsync(x =>
                x.User.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var tienda = await context.Tiendas.Include(x => x.User).Include(x =>
                x.Address).FirstOrDefaultAsync(x => x.User.Id == id);

            return mapper.Map<ShopDTO>(tienda);
        }

        [HttpGet("ObtenerPorEmailUsuario/{email}")]
        public async Task<ActionResult<ShopDTO>> ObtenerPorEmailUsuario(string email)
        {
            var existe = await context.Tiendas.AnyAsync(x =>
                x.User.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var tienda = await context.Tiendas.Include(x => x.User).Include(x =>
                x.Address).FirstOrDefaultAsync(x => x.User.Email == email);

            return mapper.Map<ShopDTO>(tienda);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateShopDTO tiendaCreacionDTO)
        {
            var existeElUsuario = await context.Usuarios.AnyAsync(x => x.Email == tiendaCreacionDTO.User.Email);

            if (existeElUsuario)
            {
                return BadRequest($"Ya existe una tienda con el email: {tiendaCreacionDTO.User.Email}");
            }

            var tienda = mapper.Map<Shop>(tiendaCreacionDTO);

            context.Add(tienda);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
