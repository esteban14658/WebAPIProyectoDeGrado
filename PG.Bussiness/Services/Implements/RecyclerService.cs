using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PG.Bussiness.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class RecyclerService: GenericService<RecyclerDTO, CreateRecyclerDTO, Recycler>, IRecyclerService
    {
        private readonly IRecyclerRepository _recyclerRepository;
        private readonly IMapper _mapper;

        public RecyclerService(IRecyclerRepository recyclerRepository, IMapper mapper) : base(recyclerRepository, mapper)
        {
            _recyclerRepository = recyclerRepository;
            _mapper = mapper;
        }

        public Task<RecyclerDTO> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override async Task<RecyclerDTO> GetById(int id)
        {
            var exists = _recyclerRepository.Exists(id);
            if (!exists)
            {
                throw new KeyNotFoundException("User not found");
            }
            var genericResult = await _recyclerRepository.GetById(id);
            RecyclerDTO recyclerDTO = _mapper.Map<RecyclerDTO>(genericResult);
            return recyclerDTO;
        }

        public override async Task<CreateRecyclerDTO> Insert(CreateRecyclerDTO dto)
        {
            var user = _recyclerRepository.ExistUserByEmail(dto.User.Email);
            if (user)
            {
                throw new CustomConflictException("User already exist");
            }
            var recycler = _mapper.Map<Recycler>(dto);

            await _recyclerRepository.Insert(recycler);
            return dto;
        }

        public override async Task<CreateRecyclerDTO> Update(CreateRecyclerDTO dto, int id)
        {
            var exist = _recyclerRepository.Exists(id);
            if (!exist)
            {
                throw new KeyNotFoundException("recycler not found");
            }
            var recycler = _mapper.Map<Recycler>(dto);
            recycler.Id = id;

            await _recyclerRepository.Update(recycler);
            return dto;
        }

    }
}
