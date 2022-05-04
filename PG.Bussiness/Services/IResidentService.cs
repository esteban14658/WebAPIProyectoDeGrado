using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IResidentService : IGenericService<ResidentDto, CreateResidentDto>
    {
        Task<ResidentDto> GetUserById(int id);
        Task<ResidentDto> GetUserByEmail(string email);
        Task DeleteAll(int id);
    }
}
