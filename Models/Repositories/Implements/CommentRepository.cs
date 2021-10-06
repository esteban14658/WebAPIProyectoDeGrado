using PG.Models.Entitys;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.Repositories.Implements;

namespace PG.Models.Repositories.Implements
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
