using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface ICollectionPointRepository : IGenericRepository<CollectionPoint>
    {
        Task<CollectionPoint> Update(CollectionPoint entity, string stateCompare);
        Task<List<CollectionPoint>> GetByState(string state);
        Task<List<CollectionPoint>> GetByIdResident(int id, string state);
        Task<List<CollectionPoint>> GetByTypeOfMaterial(string typeOfMaterial);
        Task<List<CollectionPoint>> GetByStateAndType(string state, string type);
        Task<List<CollectionPoint>> GetByDate();
        bool Exists(int id);
        Task<List<CollectionPoint>> GetByIdRoute(int idRoute, string state);
    }
}
