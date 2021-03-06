using AutoMapper;
using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Exceptions;
using PG.Bussiness.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ShopService : GenericService<ShopDto, CreateShopDto, Shop>, IShopService
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

        public override async Task<CreateShopDto> Insert(CreateShopDto dto)
        {
            var user = _shopRepository.ExistUserByEmail(dto.User.Email);
            if (user)
            {
                throw new CustomConflictException("User already exist");
            }
            var documentIsPresent = _shopRepository.ExistsByDocument(dto.Document);
            if (documentIsPresent)
            {
                throw new CustomConflictException("Shop already exist");
            }
            dto.User.Role = "isShop";
            dto.User.State = false;
            await _accountService.Register(dto.User, "isShop", "4");
            var shop = _mapper.Map<Shop>(dto);
            await _shopRepository.Insert(shop);
            return dto;
        }

        public override async Task<ShopDto> GetById(int id)
        {
            var exist = _shopRepository.Exist(id);
            if (!exist)
            {
                throw new KeyNotFoundException("User not found");
            }
            var genericResult = await _shopRepository.GetById(id);
            var shopDto = _mapper.Map<ShopDto>(genericResult);
            return shopDto;
        }

        public override async Task<ShopDto> Update(ShopDto dto, int id)
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

        public async Task<List<ShopDto>> GetAllList()
        {
            var list = await _shopRepository.GetAll();
            List<ShopDto> result = new();
            foreach (var item in list)
            {
                var mapping = _mapper.Map<ShopDto>(item);
                result.Add(mapping);
            }
            return result;
        }

        public async Task<ShopDto> GetByEmail(string email)
        {
            var exist = _shopRepository.ExistUserByEmail(email);
            if (!exist)
            {
                throw new KeyNotFoundException("User not found");
            }
            var genericResult = await _shopRepository.GetByEmail(email);
            var shopDto = _mapper.Map<ShopDto>(genericResult);
            return shopDto;
        }

        public List<IFormFile> Base64ToImage(List<EquipmentFile> equipmentFiles)
        {
            List<IFormFile> formFiles = new List<IFormFile>();
            foreach (var eqp in equipmentFiles)
            {

                byte[] bytes = Convert.FromBase64String(eqp.File);
                MemoryStream stream = new MemoryStream(bytes);

                IFormFile file = new FormFile(stream, 0, bytes.Length, eqp.Name, eqp.Name);
                formFiles.Add(file);

            }
            return formFiles;
        }

        public IFormFile Base64ToIFormFile(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream stream = new MemoryStream(imageBytes);

            // Convert byte[] to Image
            IFormFile file = new FormFile(stream, 0, imageBytes.Length, "", "");
            return file;
        }
    }
}
