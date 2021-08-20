using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class RecicladorRepository: GenericRepository<Reciclador>, IRecicladorRepository
    {
        public RecicladorRepository(ApplicationDbContext context): base(context) 
        {
        }

    }
}
