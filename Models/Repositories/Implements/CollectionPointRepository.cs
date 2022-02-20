using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class CollectionPointRepository : GenericRepository<CollectionPoint>, ICollectionPointRepository
    {
        private readonly DbSet<CollectionPoint> _collectionPoints;
        private readonly ApplicationDbContext _context;

        public CollectionPointRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _collectionPoints = context.Set<CollectionPoint>();
        }

    }
}
