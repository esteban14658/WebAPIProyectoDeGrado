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
    [Route("api/recyclers")]
    public class RecyclerController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RecyclerController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecyclerDTO>>> Get()
        {
            var recyclers = await context.Recyclers.Include(x => x.User).ToListAsync();
            return mapper.Map<List<RecyclerDTO>>(recyclers);
        }

        [HttpGet("GetUserById/{userId:int}")]
        public async Task<ActionResult<RecyclerDTO>> GetUserById(int userId)
        {
            var exists = await context.Recyclers.AnyAsync(x =>
                x.User.Id == userId);

            if (!exists)
            {
                return NotFound();
            }
            
            var recycler = await context.Recyclers.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == userId);
            return mapper.Map<RecyclerDTO>(recycler);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<RecyclerDTO>> GetUserByEmail(string email)
        {
            var exists = await context.Recyclers.AnyAsync(x =>
                x.User.Email == email);

            if (!exists)
            {
                return NotFound();
            }

            var recycler = await context.Recyclers.Include(x => x.User).FirstOrDefaultAsync(x => 
                x.User.Email == email);
            return mapper.Map<RecyclerDTO>(recycler);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRecyclerDTO createRecyclerDTO)
        {
            var userExists = await context.Users.AnyAsync(x => x.Email == createRecyclerDTO.User.Email);

            if (userExists)
            {
                return BadRequest($"There is already a recycler with the email: {createRecyclerDTO.User.Email}");
            }

            var recycler = mapper.Map<Recycler>(createRecyclerDTO);

            context.Add(recycler);
            await context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Updates a recycler
        /// </summary>
        /// <param name="createRecyclerDTO"></param>
        /// <param name="id"></param>
        /// <returns>A response HTTP</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateRecyclerDTO createRecyclerDTO, int id)
        {
            var exist = await context.Recyclers.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            var recycler = mapper.Map<Recycler>(createRecyclerDTO);
            recycler.Id = id;

            context.Update(recycler);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Recyclers.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Recycler() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}