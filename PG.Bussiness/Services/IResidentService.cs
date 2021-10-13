using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IResidentService : IGenericService<ResidentDTO, CreateResidentDTO>
    {
        Task<ResidentDTO> GetUserById(int id);
        Task<ResidentDTO> GetUserByEmail(string email);
        Task DeleteAll(int id);
    }
}
