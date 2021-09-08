using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IGenericService<TDto> where TDto: class
    {
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Insert(TDto dto);
        Task<TDto> Update(TDto dto);
        Task Delete(int id);
    }
}
