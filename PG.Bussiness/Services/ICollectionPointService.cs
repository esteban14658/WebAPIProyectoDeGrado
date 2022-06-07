using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface ICollectionPointService : IGenericService<CollectionPointDto, CreateCollectionPointDto>
    {
        Task<PaginateDto<CollectionPointDto>> GetByState(int page, int amount, string state);
        Task<PaginateDto<CollectionPointDto>> GetByTypeOfMaterial(int page, int amount, string typeOfMaterial);
        Task<PaginateDto<CollectionPointDto>> GetByIdResident(int page, int amount, int idResident, string state);
        Task<PaginateDto<CollectionPointDto>> GetByDate(int page, int amount);
        Task<PaginateDto<CollectionPointDto>> GetByStateAndType(int page, int amount, string state, string type);
        Task<int> AssignToRoute(CollectionPointUpdateDto dto, string stateCompare);
        IFormFile Base64ToIFormFile(string base64String);
        Task<PaginateDto<CollectionPointDto>> GetByIdRoute(int page, int amount, int idRoute, string state);
        Task<List<CollectionPointDto>> GetByDate(string date);
        Task Disassociate();
    }
}
