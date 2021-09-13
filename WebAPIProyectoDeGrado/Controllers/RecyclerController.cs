﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/recyclers")]
    public class RecyclerController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IRecyclerService recyclerService;

        public RecyclerController(ApplicationDbContext context, IMapper mapper, IRecyclerService recyclerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.recyclerService = recyclerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecyclerDTO>>> Get()
        {
            var recyclers = await recyclerService.GetAll();
            if (recyclers.Count == 0)
            {
                return NoContent();
            }
            return Ok(recyclers);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<RecyclerDTO>> GetById(int id)
        {
            var recycler = await recyclerService.GetById(id);
            return recycler;
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
        public async Task<ActionResult> Post([FromBody] CreateRecyclerDTO recyclerDTO)
        {
            var recycler = await recyclerService.Insert(recyclerDTO);
            return Accepted(recycler);
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
            /*var exist = await context.Recyclers.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            var recycler = mapper.Map<Recycler>(createRecyclerDTO);
            recycler.Id = id;

            context.Update(recycler);
            await context.SaveChangesAsync();*/
            var recycler = await recyclerService.Update(createRecyclerDTO, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            /*var existe = await context.Recyclers.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Recycler() { Id = id });
            await context.SaveChangesAsync();*/
            await recyclerService.Delete(id);
            return NoContent();
        }

    }
}