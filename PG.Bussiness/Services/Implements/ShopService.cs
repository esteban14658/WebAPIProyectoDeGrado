using AutoMapper;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ShopService : GenericService<ShopDTO, CreateShopDTO, Shop>, IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository shopRepository, IMapper mapper) : base(shopRepository, mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }
    }
}
