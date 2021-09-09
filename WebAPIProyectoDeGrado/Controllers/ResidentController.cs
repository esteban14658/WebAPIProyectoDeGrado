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
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/residents")]
    public class ResidentController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IResidentService residentService;

        public ResidentController(ApplicationDbContext context, IMapper mapper, IResidentService residentService)
        {
            this.context = context;
            this.mapper = mapper;
            this.residentService = residentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResidentDTO>>> Get()
        {
            var recyclers = await residentService.GetAll();
            try
            {
                return Ok(recyclers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<ActionResult<ResidentDTO>> GetUserById(int id)
        {
            var exists = await context.Residents.AnyAsync(x =>
                x.User.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            var resident = await context.Residents.Include(x => x.User).Include(x =>
                x.AddressList).FirstOrDefaultAsync(x => x.User.Id == id);

            return mapper.Map<ResidentDTO>(resident);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<ResidentDTO>> GetUserByEmail(string email)
        {
            var exists = await context.Residents.AnyAsync(x =>
                x.User.Email == email);

            if (!exists)
            {
                return NotFound();
            }

            var resident = await context.Residents.Include(x => x.User).Include(x =>
                x.AddressList).FirstOrDefaultAsync(x => x.User.Email == email);

            return mapper.Map<ResidentDTO>(resident);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateResidentDTO createResidentDTO)
        {
            var userExists = await context.Users.AnyAsync(x => x.Email == createResidentDTO.User.Email);

            if (userExists)
            {
                return BadRequest($"There is already a resident with the email: {createResidentDTO.User.Email}");
            }

            var resident = mapper.Map<Resident>(createResidentDTO);

            context.Add(resident);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateResidentDTO createResidentDTO, int id)
        {
            var exist = await context.Recyclers.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            var resident = mapper.Map<Resident>(createResidentDTO);
            resident.Id = id;

            context.Update(resident);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Residents.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Resident() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
