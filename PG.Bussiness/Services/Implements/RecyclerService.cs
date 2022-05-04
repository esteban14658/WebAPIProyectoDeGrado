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
    public class RecyclerService : GenericService<RecyclerDto, CreateRecyclerDto, Recycler>, IRecyclerService
    {
        private readonly IRecyclerRepository _recyclerRepository;
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountService;

        public RecyclerService(IRecyclerRepository recyclerRepository, IMapper mapper, IAccountsService accountService) : base(recyclerRepository, mapper)
        {
            _recyclerRepository = recyclerRepository;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<RecyclerDto> GetUserByEmail(string email)
        {
            var exist = _recyclerRepository.ExistUserByEmail(email);
            if (!exist)
            {
                throw new KeyNotFoundException("recycler not found");
            }
            var genericResult = await _recyclerRepository.GetUserByEmail(email);
            var recyclerDTO = _mapper.Map<RecyclerDto>(genericResult);
            return recyclerDTO;
        }

        public override async Task<RecyclerDto> GetById(int id)
        {
            var exists = _recyclerRepository.Exists(id);
            if (!exists)
            {
                throw new KeyNotFoundException("User not found");
            }
            var genericResult = await _recyclerRepository.GetById(id);
            RecyclerDto recyclerDTO = _mapper.Map<RecyclerDto>(genericResult);
            return recyclerDTO;
        }

        public override async Task<CreateRecyclerDto> Insert(CreateRecyclerDto dto)
        {
            var user = _recyclerRepository.ExistUserByEmail(dto.User.Email);
            if (user)
            {
                throw new CustomConflictException("User already exist");
            }
            dto.User.Role = "Reciclador";
            await _accountService.Register(dto.User, "isRecycler", "2");
            var recycler = _mapper.Map<Recycler>(dto);

            await _recyclerRepository.Insert(recycler);
            return dto;
        }

        public override async Task<RecyclerDto> Update(RecyclerDto dto, int id)
        {
            var exist = _recyclerRepository.Exists(id);
            if (!exist)
            {
                throw new KeyNotFoundException("recycler not found");
            }
            dto.User = null;
            var recycler = _mapper.Map<Recycler>(dto);
            recycler.Id = id;
            await _recyclerRepository.Update(recycler);
            return dto;
        }

        public async Task<RecyclerDto> GetUserById(int id)
        {
            var exist = _recyclerRepository.ExistUserById(id);
            if (!exist)
            {
                throw new KeyNotFoundException("recycler not found");
            }
            var genericResult = await _recyclerRepository.GetUserById(id);
            var recyclerDTO = _mapper.Map<RecyclerDto>(genericResult);
            return recyclerDTO;
        }
    }
}
