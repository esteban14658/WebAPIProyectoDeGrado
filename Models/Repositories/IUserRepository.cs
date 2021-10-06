using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool ExistsByEmail(string email);
        Task<User> GetByEmail(string email);
    }
}
