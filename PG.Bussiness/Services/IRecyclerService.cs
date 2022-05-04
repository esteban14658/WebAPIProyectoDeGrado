using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IRecyclerService : IGenericService<RecyclerDto, CreateRecyclerDto>
    {
        Task<RecyclerDto> GetUserByEmail(string email);
        Task<RecyclerDto> GetUserById(int id);
    }
}
