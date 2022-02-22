using PG.Bussiness.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface ICollectionPointService : IGenericService<CollectionPointDTO, CreateCollectionPointDTO>
    {
        Task<PaginateDTO<CollectionPointDTO>> GetByState(int page, int amount, string state);
    }
}
