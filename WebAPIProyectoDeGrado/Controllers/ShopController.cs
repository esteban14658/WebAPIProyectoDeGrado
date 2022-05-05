using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Bussiness.Services;
using PG.Presentation.Storage;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task<ActionResult<PaginateDto<ShopDto>>> Get(int page, int amount)
        {
            var shops = await _shopService.GetAll(page, amount);
            return Ok(shops);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ShopDto>> GetById(int id)
        {
            var shop = await _shopService.GetById(id);
            return Ok(shop);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<ShopDto>> GetByEmail(string email)
        {
            var shop = await _shopService.GetByEmail(email);
            return Ok(shop);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ShopDto dto, int id)
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
        public async Task<ActionResult<List<ShopDto>>> GetAllList()
        {
            var shops = await _shopService.GetAllList();
            return Ok(shops);
        }


        [HttpPut("UpdateImageJson/{id:int}/{extension}")]
        public async Task<ActionResult> UpdateImageJson(int id, [FromBody] ShopUpdateDto shopUpdateDTO, string extension)
        {
            var call = _shopService.Base64ToIFormFile(shopUpdateDTO.Image);


            var shopDB = await _context.Shops.FirstOrDefaultAsync(x => x.Id == id);
            if (shopDB == null) { return NotFound(); }
            shopDB = _mapper.Map<Shop>(shopUpdateDTO);
            if (shopUpdateDTO.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await call.CopyToAsync(memoryStream);
                    var contents = memoryStream.ToArray();
                    shopDB.Image = await _imageStorage.EditFile(contents, "." + extension, container,
                        shopDB.Image,
                        "image/" + extension);
                }
            }
            var query = from s in _context.Shops
                        where s.Id == shopDB.Id
                        select s;
            foreach (Shop s in query)
            {
                s.Image = shopDB.Image;
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] CreateShopDto createShopDTO)
        {
            var shop = await _shopService.Insert(createShopDTO);
            return Created("", shop);
        }
    }
}