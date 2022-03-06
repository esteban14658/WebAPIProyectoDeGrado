using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PG.Bussiness.DTOs;
using PG.Bussiness.Exceptions;
using PG.Presentation.Storage;
using System.Collections.Generic;
using System.IO;
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
        private readonly IImageStorage _imageStorage;
        private readonly IMapper _mapper;
        private readonly string container = "shops";
        private readonly ApplicationDbContext _context;

        public ShopController(IShopService shopService, IImageStorage imageStorage,
            IMapper mapper, ApplicationDbContext context)
        {
            _shopService = shopService;
            _imageStorage = imageStorage;
            _mapper = mapper;
            _context = context;
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

        [HttpGet("GetAllList")]
        public async Task<ActionResult<List<ShopDTO>>> GetAllList()
        {
            var shops = await _shopService.GetAllList();
            return Ok(shops);
        }

        [HttpPost("Post2")]
        [AllowAnonymous]
        public async Task<ActionResult> Post2([FromForm] CreateShopDTO createShopDTO)
        {
            var verify = _context.Shops.FirstOrDefaultAsync(x => 
                x.User.Email.Equals(createShopDTO.User.Email));
            if (verify != null)
            {
                return Conflict("The shop is already exists");
            }
            var shop = _mapper.Map<Shop>(createShopDTO);
            if (createShopDTO.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await createShopDTO.Image.CopyToAsync(memoryStream);
                    var contents = memoryStream.ToArray();
                    var extension = Path.GetExtension(createShopDTO.Image.FileName);
                    shop.Image = await _imageStorage.SaveFile(contents, extension, container,
                        createShopDTO.Image.ContentType);
                }
            }
            _context.Add(shop);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<ShopDTO>(shop);
            return Created("", result);
        }
    }
}
