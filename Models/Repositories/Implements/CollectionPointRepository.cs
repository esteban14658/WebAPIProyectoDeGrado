using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class CollectionPointRepository: GenericRepository<CollectionPoint>, ICollectionPointRepository
    {
        public CollectionPointRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
