using AutoMapper;
using PG.Bussiness.Exceptions;
using PG.Bussiness.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ShopService : GenericService<ShopDTO, CreateShopDTO, Shop>, IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountService;

        public ShopService(IShopRepository shopRepository, IMapper mapper, IAccountsService accountsService) : base(shopRepository, mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
            _accountService = accountsService;
        }

        public override async Task<CreateShopDTO> Insert(CreateShopDTO dto)
        {
            var user = _shopRepository.ExistUserByEmail(dto.User.Email);
            if (user)
            {
                throw new CustomConflictException("User already exist");
            }
            dto.User.Role = "isShop";
            await _accountService.Register(dto.User, "isShop", "4");
            var shop = _mapper.Map<Shop>(dto);
            shop.Address.ShopId = shop.Id;
            await _shopRepository.Insert(shop);
            return dto;
        }

        public override async Task<ShopDTO> GetById(int id)
        {
            var exist = _shopRepository.Exist(id);
            if (!exist)
            {
                throw new KeyNotFoundException("User not found");
            }
            var genericResult = await _shopRepository.GetById(id);
            var shopDto = _mapper.Map<ShopDTO>(genericResult);
            return shopDto;
        }

        public override async Task<ShopDTO> Update(ShopDTO dto, int id)
        {
            var exist = _shopRepository.Exist(id);

            if (!exist)
            {
                throw new KeyNotFoundException("Shop not found");
            }
            dto.Address = null;
            dto.User = null;
            var shop = _mapper.Map<Shop>(dto);
            shop.Id = id;
            await _shopRepository.Update(shop);
            return dto;
        }

        public async Task DeleteAll(int id)
        {
            await _shopRepository.DeleteAddress(id);
            await _shopRepository.DeleteUser(id);
            await _shopRepository.Delete(id);
        }
    }
}
