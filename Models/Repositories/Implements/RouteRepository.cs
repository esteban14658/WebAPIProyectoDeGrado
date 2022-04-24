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

        public async Task<Comment> AddCommentToRoute(int idRoute, Comment comment)
        {
            var route = await _context.Routes.Include(x => x.Comment)
                .FirstOrDefaultAsync(x => x.Id == idRoute);
            if (route == null)
            {
                throw new KeyNotFoundException("the route is not registered");
            }
            if (route.Comment != null)
            {
                return null;
            }
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
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

        public async override Task<Route> Update(Route entity)
        {
            var getById = await _routes
                .Include(x => x.Comment)
                .FirstOrDefaultAsync(x => x.Id == entity.Id);
            var query = from r in _context.Routes
                        where r.Id == entity.Id
                        select r;
            foreach (Route r in query)
            {
                r.Comment = getById.Comment;
                r.StartDate = getById.StartDate;
                r.EndDate = entity.EndDate;
                r.Recycler = getById.Recycler;
            }
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Route> GetById(int id)
        {
            var result = await _routes
                .Include(x => x.CollectionPoints)
                .Include(x => x.Comment)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public bool ExistsActiveRoute(int idRecycler)
        {
            return _routes.Any(x => x.Recycler == idRecycler && x.EndDate == null);
        }

        public async Task<List<Route>> GetByIdRecycler(int idRecycler)
        {
            var result = await _routes
                .Include(x => x.CollectionPoints)
                .Include(x => x.Comment)
                .Where(x => x.Recycler == idRecycler)
                .ToListAsync();
            return result;
        }
    }
}
