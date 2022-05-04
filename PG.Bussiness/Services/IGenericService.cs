using PG.Bussiness.DTOs;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IGenericService<TDto, TCreateDTO> where TDto : class where TCreateDTO : class
    {
        Task<PaginateDto<TDto>> GetAll(int page, int amount);
        Task<TDto> GetById(int id);
        Task<TCreateDTO> Insert(TCreateDTO dto);
        Task<TDto> Update(TDto dto, int id);
        Task Delete(int id);
    }
}
