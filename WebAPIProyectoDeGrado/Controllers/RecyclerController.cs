using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PG.Bussiness.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/recyclers")]
    public class RecyclerController: ControllerBase
    {
        private readonly IRecyclerService recyclerService;

        public RecyclerController(IRecyclerService recyclerService)
        {
            this.recyclerService = recyclerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecyclerDTO>>> Get()
        {

            var recyclers = await recyclerService.GetAll();
            return recyclers;

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
            var recycler = await recyclerService.GetUserById(userId);
            return Ok(recycler);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<RecyclerDTO>> GetUserByEmail(string email)
        {
            var recycler = await recyclerService.GetUserByEmail(email);
            return Ok(recycler);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRecyclerDTO recyclerDTO)
        {
            var recycler = await recyclerService.Insert(recyclerDTO);
            return Created("",recycler);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(RecyclerDTO recyclerDTO, int id)
        {
            await recyclerService.Update(recyclerDTO, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await recyclerService.Delete(id);
            return NoContent();
        }
    }
}