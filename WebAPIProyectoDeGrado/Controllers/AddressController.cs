using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> Post([FromBody] CreateAddressDto createAddressDTO)
        {
            var address = await _addressService.Insert(createAddressDTO);
            return Created("", address);
        }

        [HttpPost("AddAddressToResident/{idResident:int}")]
        [AllowAnonymous]
        public async Task<ActionResult> AddAddressToResident([FromBody] CreateAddressDto createAddressDTO, int idResident)
        {
            var address = await _addressService.AddAddressToResident(idResident, createAddressDTO);
            return Created("", address);
        }

        [HttpPost("AddAddressToShop/{idShop:int}")]
        [AllowAnonymous]
        public async Task<ActionResult> AddAddressToShop([FromBody] CreateAddressDto createAddressDTO, int idShop)
        {
            var address = await _addressService.AddAddressToShop(idShop, createAddressDTO);
            return Created("", address);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(AddressDto addressDTO, int id)
        {
            await _addressService.Update(addressDTO, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressService.Delete(id);
            return NoContent();
        }
    }
}
