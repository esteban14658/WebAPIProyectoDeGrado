using PG.Models.Entitys;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Models.Repositories
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        bool Exists(int id);
        Task<Comment> AddCommentToRoute(int idRoute, Comment comment);
    }
}
