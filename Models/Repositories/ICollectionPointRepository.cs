using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface ICollectionPointRepository : IGenericRepository<CollectionPoint>
    {
        Task<List<CollectionPoint>> GetByState(string state);
        Task<List<CollectionPoint>> GetByTypeOfMaterial(string typeOfMaterial);
        Task<List<CollectionPoint>> GetByDate();
        bool Exists(int id);
    }
}
