using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IGenericService<TDto, TCreateDTO> where TDto: class where TCreateDTO: class
    {
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TCreateDTO> Insert(TCreateDTO dto);
        Task<TCreateDTO> Update(TCreateDTO dto, int id);
        Task Delete(int id);
    }
}
