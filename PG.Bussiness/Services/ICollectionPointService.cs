using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface ICollectionPointService : IGenericService<CollectionPointDTO, CreateCollectionPointDTO>
    {
        Task<PaginateDTO<CollectionPointDTO>> GetByState(int page, int amount, string state);
        Task<PaginateDTO<CollectionPointDTO>> GetByTypeOfMaterial(int page, int amount, string typeOfMaterial);
        Task<PaginateDTO<CollectionPointDTO>> GetByIdResident(int page, int amount, int idResident, string state);
        Task<PaginateDTO<CollectionPointDTO>> GetByDate(int page, int amount);
        Task<int> AssignToRoute(CollectionPointUpdateDTO dto, string stateCompare);
        IFormFile Base64ToIFormFile(string base64String);
    }
}
