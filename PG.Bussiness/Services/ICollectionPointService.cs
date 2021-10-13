using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface ICollectionPointService : IGenericService<CollectionPointDTO, CreateCollectionPointDTO>
    {
        Task<List<CollectionPointDTO>> GetByEmail(string email);
    }
}
