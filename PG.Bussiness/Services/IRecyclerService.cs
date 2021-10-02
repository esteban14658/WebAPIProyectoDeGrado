using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IRecyclerService : IGenericService<RecyclerDTO, CreateRecyclerDTO>
    {
        Task<RecyclerDTO> GetUserByEmail(string email);
        Task<RecyclerDTO> GetUserById(int id);
    }
}
