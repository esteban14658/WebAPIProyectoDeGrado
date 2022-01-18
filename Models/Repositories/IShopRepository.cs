using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IShopRepository : IGenericRepository<Shop>
    {
        bool ExistUserByEmail(string email);
        bool Exist(int id);
        Task DeleteAddress(int idShop);
        Task DeleteUser(int idShop);

    }
}
