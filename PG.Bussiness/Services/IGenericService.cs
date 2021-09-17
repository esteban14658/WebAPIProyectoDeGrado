using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IGenericService<TDto, TCreateDTO> where TDto: class where TCreateDTO: class
    {
        Task<PaginateDTO<TDto>> GetAll(int page, int amount);
        Task<TDto> GetById(int id);
        Task<TCreateDTO> Insert(TCreateDTO dto);
        Task<TDto> Update(TDto dto, int id);
        Task Delete(int id);
    }
}
