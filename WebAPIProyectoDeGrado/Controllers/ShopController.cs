using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using PG.Bussiness.Exceptions;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/shops")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsShop")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDTO<ShopDTO>>> Get(int page, int amount)
        {
            var shops = await _shopService.GetAll(page, amount);
            return Ok(shops);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ShopDTO>> GetById(int id)
        {
            var shop = await _shopService.GetById(id);
            return Ok(shop);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateShopDTO createShopDTO)
        {
            try
            {
                var shop = await _shopService.Insert(createShopDTO);
                return Created("", shop);
            }
            catch (AppException e)
            {
                throw e;
            }
        }
    

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ShopDTO dto, int id)
        {
            await _shopService.Update(dto, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _shopService.DeleteAll(id);
            return NoContent();
        }
    }
}
