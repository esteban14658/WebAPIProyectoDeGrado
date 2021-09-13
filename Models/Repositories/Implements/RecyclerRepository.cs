using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class RecyclerRepository: GenericRepository<Recycler>, IRecyclerRepository
    {
        private readonly DbSet<Recycler> _recycler;
        private readonly ApplicationDbContext _context;

        public RecyclerRepository(ApplicationDbContext context): base(context) 
        {
            _recycler = context.Set<Recycler>();
            _context = context;
        }

        public bool Exists(int id)
        {
            return _recycler.Any(x => x.Id == id);
        }

        public bool ExistUserByEmail(string email)
        {
            return _recycler.Any(x => x.User.Email.Equals(email));
        }

        public override async Task<List<Recycler>> GetAll()
        {
            return await _recycler.Include(x => x.User).ToListAsync();
        }

        public override async Task<Recycler> Update(Recycler entity)
        {
            _recycler.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public override Task<Recycler> GetById(int id)
        {
            return _recycler.Include(x => x.User).FirstOrDefaultAsync(x => 
                x.Id == id);
        }

        public Task<Recycler> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
