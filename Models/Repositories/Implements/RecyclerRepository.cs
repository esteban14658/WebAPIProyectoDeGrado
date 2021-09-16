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


        public override async Task<Recycler> GetById(int id)
        {
            return await _recycler.Include(x => x.User).FirstOrDefaultAsync(x => 
                x.Id == id);
        }

        public async Task<Recycler> GetUserByEmail(string email)
        {
            return await _recycler.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Email == email);
        }

        public async Task<Recycler> GetUserById(int id)
        {
            return await _recycler.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == id);
        }

        public bool ExistUserById(int id)
        {
            return _recycler.Any(x => x.User.Id == id);
        }
    }
}
