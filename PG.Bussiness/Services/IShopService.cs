using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IShopService : IGenericService<ShopDTO, CreateShopDTO>
    {
        Task DeleteAll(int id);
        Task<List<ShopDTO>> GetAllList();
        Task<ShopDTO> GetByEmail(string email);
    }
}