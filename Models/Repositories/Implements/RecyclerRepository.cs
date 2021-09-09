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
        public RecyclerRepository(ApplicationDbContext context): base(context) 
        {
            _recycler = context.Set<Recycler>();
        }

        public override async Task<List<Recycler>> GetAll()
        {
            return await _recycler.Include(x => x.User).ToListAsync();
        }

        public Task<Recycler> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
