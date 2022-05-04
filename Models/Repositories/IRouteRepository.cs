using PG.Models.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Models.Repositories
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        bool Exists(int id);
        Task<Comment> AddCommentToRoute(int idRoute, Comment comment);
        bool ExistsActiveRoute(int idRecycler);
        Task<List<Route>> GetByIdRecycler(int idRecycler);
        Task<List<Route>> GetByDate(string date);
    }
}
