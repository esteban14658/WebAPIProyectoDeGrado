using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class RecyclerRepository: GenericRepository<Recycler>, IRecyclerRepository
    {
        public RecyclerRepository(ApplicationDbContext context): base(context) 
        {
        }

    }
}
