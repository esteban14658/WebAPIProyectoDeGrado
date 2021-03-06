using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IResidentRepository : IGenericRepository<Resident>
    {
        Task<Resident> GetUserByEmail(string email);
        Task<Resident> GetUserById(int id);
        Task DeleteAddressList(int idResident);
        Task DeleteUser(int idResident);
        bool Exists(int id);
        bool ExistUserByEmail(string email);
        bool ExistUserById(int id);
    }
}
