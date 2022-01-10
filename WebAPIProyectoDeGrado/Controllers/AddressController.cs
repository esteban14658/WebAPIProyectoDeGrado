﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateAddressDTO createAddressDTO)
        {
            var address = await _addressService.Insert(createAddressDTO);
            return Created("", address);
        }

        [HttpPost("AddAddressToResident/{idResident:int}")]
        [AllowAnonymous]
        public async Task<ActionResult> AddAddressToResident([FromBody] CreateAddressDTO createAddressDTO, int idResident)
        {
            var address = await _addressService.AddAddressToResident(idResident,createAddressDTO);
            return Created("", address);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressService.Delete(id);
            return NoContent();
        }
    }
}
