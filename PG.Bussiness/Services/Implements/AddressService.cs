using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class AddressService: GenericService<AddressDTO, CreateAddressDTO, Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper): base(addressRepository, mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
    }
}
