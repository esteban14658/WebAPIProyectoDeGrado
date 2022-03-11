using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.Repositories.Implements;

namespace PG.Models.Repositories.Implements
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Route> _routes;

        public RouteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _routes = context.Set<Route>();
        }

        public bool Exists(int id)
        {
            return _routes.Any(x => x.Id == id);
        }

        public override async Task<List<Route>> GetAll()
        {
            var result = await _routes.Include(
                x => x.Comment).ToListAsync();
            return result;
        }

        public override async Task<Route> GetById(int id)
        {
            var result = await _routes.Include(x => x.CollectionPoints)
                .Include(x => x.Comment)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
