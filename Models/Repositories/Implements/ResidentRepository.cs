using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class ResidentRepository: GenericRepository<Resident>, IResidentRepository
    {
        private readonly DbSet<Resident> _resident;
        public ResidentRepository(ApplicationDbContext context): base(context)
        {
            _resident = context.Set<Resident>();
        }

        
        public override async Task<List<Resident>> GetAll()
        {
            return await _resident.Include(x => x.User).Include(x =>
                x.AddressList).ToListAsync();
        }
    }
}
