using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.Repositories.Implements;

namespace PG.Models.Repositories.Implements
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly DbSet<Comment> _comment;
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _comment = context.Set<Comment>();
            _context = context;
        }

        public async Task DeleteByUserId(int idUser)
        {
            var entity = await _comment.FirstOrDefaultAsync(x => x.UserId == idUser);
            if (entity == null)
            {
                throw new KeyNotFoundException("The entity is null");
            }
            _comment.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllByIdUser(int idUser)
        {
            var result = await _comment.Where(x => x.UserId == idUser)
                .ToListAsync();
            return result;
        }


    }
}
