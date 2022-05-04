using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IShopService : IGenericService<ShopDto, CreateShopDto>
    {
        Task DeleteAll(int id);
        Task<List<ShopDto>> GetAllList();
        Task<ShopDto> GetByEmail(string email);
        List<IFormFile> Base64ToImage(List<EquipmentFile> equipmentFiles);
        IFormFile Base64ToIFormFile(string base64String);
    }
}