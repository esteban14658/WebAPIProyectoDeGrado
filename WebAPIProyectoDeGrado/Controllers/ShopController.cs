using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PG.Bussiness.DTOs;
using PG.Bussiness.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Services;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/shops")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsShop")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ShopController(ApplicationDbContext context, IMapper mapper, IShopService shopService)
        {
            _shopService = shopService;
            this.context = context;
            this.mapper = mapper;
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

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<ShopDTO>> GetUserByEmail(string email)
        {
            var existe = await context.Shops.AnyAsync(x =>
                x.User.Email == email);

            if (!existe)
            {
                return NotFound();
            }

            var shop = await context.Shops.Include(x => x.User).Include(x =>
                x.Address).FirstOrDefaultAsync(x => x.User.Email == email);

            return mapper.Map<ShopDTO>(shop);
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
            /*var existe = await context.Shops.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Shop() { Id = id });
            await context.SaveChangesAsync();*/
            await _shopService.DeleteAll(id);
            return NoContent();
        }
    }
}
