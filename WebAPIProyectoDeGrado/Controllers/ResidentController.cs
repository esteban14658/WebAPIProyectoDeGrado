﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/residents")]
    public class ResidentController: ControllerBase
    {
        private readonly IResidentService residentService;

        public ResidentController(IResidentService residentService)
        {
            this.residentService = residentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResidentDTO>>> Get()
        {
            var residents = await residentService.GetAll();
            return Ok(residents);
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<ActionResult<ResidentDTO>> GetUserById(int id)
        {
            var resident = await residentService.GetUserById(id);
            return Ok(resident);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<ResidentDTO>> GetUserByEmail(string email)
        {
            var resident = await residentService.GetUserByEmail(email);
            return Ok(resident);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateResidentDTO createResidentDTO)
        {
            var resident = await residentService.Insert(createResidentDTO);
            return Created("", resident);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateResidentDTO createResidentDTO, int id)
        {
            await residentService.Update(createResidentDTO, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await residentService.Delete(id);
            return NoContent();
        }
    }
}
