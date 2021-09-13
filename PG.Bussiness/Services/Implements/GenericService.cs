using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using PG.Bussiness.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class GenericService<TDto, TCreateDTO, TEntity> : IGenericService<TDto, TCreateDTO> where TDto : class where TCreateDTO: class where TEntity : class 
    {
        private readonly IGenericRepository<TEntity> genericRepository;
        private readonly IMapper mapper;


        public GenericService()
        {

        }

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TDto>> GetAll()
        {
            var genericResult = await genericRepository.GetAll();

            List<TDto> genericList = new();
            foreach (var item in genericResult)
            {
                var result = mapper.Map<TDto>(item);
                genericList.Add(result);
            }
            return genericList;
        }

        public virtual async Task<TDto> GetById(int id)
        {
            var genericResult = await genericRepository.GetById(id);
            TDto dto = mapper.Map<TDto>(genericResult);
            return dto;
        }

        public virtual async Task<TCreateDTO> Insert(TCreateDTO dto)
        {
            TEntity entity = mapper.Map<TEntity>(dto);
            await genericRepository.Insert(entity);
            return dto;
        }

        public Task<TDto> Update(TDto dto)
        {
            throw new NotImplementedException();
        }

        /*public async Task Delete(int id)
        {
            await genericRepository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await genericRepository.Insert(entity);
        }*/


    }
}
