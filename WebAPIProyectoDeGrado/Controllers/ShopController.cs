using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class ShopController : ControllerBase
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
            var shops = await context.Shops.Include(x =>
                x.User).Include(x => x.Address).ToListAsync();
            return mapper.Map<List<ShopDTO>>(shops);
        }

        [HttpGet("GetUserById/{id:int}")]
        public async Task<ActionResult<ShopDTO>> GetUserById(int id)
        {
            var exists = await context.Shops.AnyAsync(x =>
                x.User.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            var shop = await context.Shops.Include(x => x.User).Include(x =>
                x.Address).FirstOrDefaultAsync(x => x.User.Id == id);

            return mapper.Map<ShopDTO>(shop);
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
        public async Task<ActionResult> Post([FromBody] CreateShopDTO createShopDTO)
        {
            var userExists = await context.Users.AnyAsync(x => x.Email == createShopDTO.User.Email);

            if (userExists)
            {
                return BadRequest($"There is already a shop with the email: {createShopDTO.User.Email}");
            }

            var shop = mapper.Map<Shop>(createShopDTO);

            context.Add(shop);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateShopDTO createShopDTO, int id)
        {
            var exist = await context.Shops.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            var shop = mapper.Map<Shop>(createShopDTO);
            shop.Id = id;

            context.Update(shop);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Shops.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Shop() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
