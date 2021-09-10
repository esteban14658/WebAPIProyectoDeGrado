using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PG.Bussiness.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class RecyclerService: GenericService<RecyclerDTO, Recycler>, IRecyclerService
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
    }
}
