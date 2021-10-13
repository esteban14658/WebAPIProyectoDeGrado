using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _user;
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _user = context.Set<User>();
            _context = context;
        }

        public bool ExistsByEmail(string email)
        {
            return _user.Any(x => x.Email.Equals(email));
        }

        public Task<User> GetByEmail(string email)
        {
            var result = _user.FirstOrDefaultAsync(x => x.Email.Equals(email));
            return result;
        }

        public override async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");
            }
            _user.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
