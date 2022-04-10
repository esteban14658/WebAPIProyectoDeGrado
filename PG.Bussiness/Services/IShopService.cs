using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs.GetDTOs;
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
        List<IFormFile> Base64ToImage(List<EquipmentFile> equipmentFiles);
        IFormFile Base64ToIFormFile(string base64String);
    }
}