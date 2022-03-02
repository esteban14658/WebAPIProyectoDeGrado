using PG.Models.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Models.Repositories
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        bool Exists(int id);
    }
}
