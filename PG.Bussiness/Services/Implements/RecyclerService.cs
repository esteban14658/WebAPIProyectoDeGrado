using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class RecyclerService: GenericService<RecyclerDTO, Recycler>, IRecyclerService
    {
        private readonly IRecyclerRepository _recicladorRepository;
        private readonly IMapper _mapper;

        public RecyclerService(IRecyclerRepository recicladorRepository, IMapper mapper) : base(recicladorRepository, mapper)
        {
            _recicladorRepository = recicladorRepository;
            _mapper = mapper;
        }


        public async Task<List<RecyclerDTO>> GetAllRecyclers()
        {
            var genericResult = await _recicladorRepository.GetAllRecyclers();
            List<RecyclerDTO> recyclerDTOs = new List<RecyclerDTO>();

            foreach (var item in genericResult)
            {
                var result = _mapper.Map<RecyclerDTO>(item);
                recyclerDTOs.Add(result);
            }
            return recyclerDTOs;
        }
    }
}
