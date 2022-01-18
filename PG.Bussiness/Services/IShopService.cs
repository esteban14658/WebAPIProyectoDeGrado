using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IShopService : IGenericService<ShopDTO, CreateShopDTO>
    {
        Task DeleteAll(int id);
    }
}