using AutoMapper;
using PG.Bussiness.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class AddressService : GenericService<AddressDto, CreateAddressDto, Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper) : base(addressRepository, mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreateAddressDto> AddAddressToResident(int idResident, CreateAddressDto dto)
        {
            var address = _mapper.Map<Address>(dto);
            await _addressRepository.AddAddressToResident(idResident, address);
            return dto;
        }

        public async override Task<CreateAddressDto> Insert(CreateAddressDto dto)
        {
            var address = _mapper.Map<Address>(dto);
            await _addressRepository.Insert(address);
            return dto;
        }

        public async override Task Delete(int id)
        {
            await _addressRepository.Delete(id);
        }

        public async Task<CreateAddressDto> AddAddressToShop(int idShop, CreateAddressDto dto)
        {
            var address = _mapper.Map<Address>(dto);
            var result = await _addressRepository.AddAddressToShop(idShop, address);
            if (result == null)
            {
                throw new CustomConflictException("The store user already has an address assigned");
            }
            return dto;
        }

        public override async Task<AddressDto> Update(AddressDto dto, int id)
        {
            var exist = _addressRepository.Exists(id);
            if (!exist)
            {
                throw new KeyNotFoundException("Address not found");
            }
            var getAddressDB = _addressRepository.GetById(id);
            var address = _mapper.Map<Address>(dto);
            address.Id = id;
            address.ShopId = getAddressDB.Result.ShopId;
            address.CollectionPointId = getAddressDB.Result.CollectionPointId;
            await _addressRepository.Update(address);
            return dto;
        }
    }
}
