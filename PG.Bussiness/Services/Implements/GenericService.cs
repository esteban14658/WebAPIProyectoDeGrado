using AutoMapper;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class GenericService<TDto, TCreateDTO, TEntity> : IGenericService<TDto, TCreateDTO> where TDto : class where TCreateDTO : class where TEntity : class
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

        public virtual async Task Delete(int id)
        {
            await genericRepository.Delete(id);
        }

        public async Task<PaginateDTO<TDto>> GetAll(int page, int amount)
        {
            var genericResult = await genericRepository.GetAll();
            List<TDto> genericList = new();
            foreach (var item in genericResult)
            {
                var result = mapper.Map<TDto>(item);
                genericList.Add(result);
            }
            var paged = PagedList<TDto>.Create(genericList, page, amount);
            PaginateDTO<TDto> paginate = new()
            {
                Page = page,
                Size = paged.Count,
                NumberOfRecords = genericResult.Count,
                Records = paged
            };
            return paginate;
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

        public virtual async Task<TDto> Update(TDto dto, int id)
        {
            var mapping = mapper.Map<TEntity>(dto);
            await genericRepository.Update(mapping);
            return dto;
        }

    }
}
