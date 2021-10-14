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

        public async Task<List<CollectionPoint>> GetByEmail(string email)
        {
            var result = await _collectionPoints.Include(x => x.Address)
                .Include(x => x.User).ToListAsync();
            List<CollectionPoint> list = new();
            foreach (var item in result)
            {
                if (item.User.Email == email)
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
