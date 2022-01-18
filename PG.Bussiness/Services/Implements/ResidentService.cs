using AutoMapper;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Exceptions;
using PG.Bussiness.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ResidentService : GenericService<ResidentDTO, CreateResidentDTO, Resident>, IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountService;

        public ResidentService(IResidentRepository residentRepository, IMapper mapper, IAccountsService accountService) : base(residentRepository, mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<ResidentDTO> GetUserByEmail(string email)
        {
            var exist = _residentRepository.ExistUserByEmail(email);
            if (!exist)
            {
                throw new KeyNotFoundException("Resident not found");
            }
            var genericResult = await _residentRepository.GetUserByEmail(email);
            var residentDTO = _mapper.Map<ResidentDTO>(genericResult);
            return residentDTO;
        }

        public async Task<ResidentDTO> GetUserById(int id)
        {
            var exist = _residentRepository.ExistUserById(id);
            if (!exist)
            {
                throw new KeyNotFoundException("recycler not found");
            }
            var genericResult = await _residentRepository.GetUserById(id);
            var residentDTO = _mapper.Map<ResidentDTO>(genericResult);
            return residentDTO;
        }

        public override async Task<ResidentDTO> GetById(int id)
        {
            var exists = _residentRepository.Exists(id);
            if (!exists)
            {
                throw new KeyNotFoundException("User not found");
            }
            var genericResult = await _residentRepository.GetById(id);
            ResidentDTO residentDTO = _mapper.Map<ResidentDTO>(genericResult);
            return residentDTO;
        }

        public override async Task<CreateResidentDTO> Insert(CreateResidentDTO dto)
        {
            var user = _residentRepository.ExistUserByEmail(dto.User.Email);
            if (user)
            {
                throw new CustomConflictException("User already exist");
            }
            dto.User.Role = "isResident";
            await _accountService.Register(dto.User, "isResident", "1");
            var resident = _mapper.Map<Resident>(dto);
            resident.User.Password = _accountService.HashPassword(dto.User);
            foreach (var item in resident.AddressList)
            {
                item.Resident = resident;
            }
            await _residentRepository.Insert(resident);
            return dto;
        }

        public override async Task<ResidentDTO> Update(ResidentDTO dto, int id)
        {
            var exist = _residentRepository.Exists(id);

            if (!exist)
            {
                throw new KeyNotFoundException("Resident not found");
            }
            dto.AddressList = null;
            dto.User = null;
            var resident = _mapper.Map<Resident>(dto);
            resident.Id = id;
            await _residentRepository.Update(resident);
            return dto;
        }

        public async Task DeleteAll(int id)
        {
            await _residentRepository.DeleteAddressList(id);
            await _residentRepository.DeleteUser(id);
            await _residentRepository.Delete(id);
        }
    }
}
