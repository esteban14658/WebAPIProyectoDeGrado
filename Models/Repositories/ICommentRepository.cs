using PG.Models.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Models.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetAllByIdUser(int idUser);
        Task DeleteByUserId(int idUser);
    }
}
