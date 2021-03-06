using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using System;
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

        public async Task<List<Route>> GetByDate(string date)
        {
            var today = DateTime.Now.ToUniversalTime().AddHours(-5);
            var filterList = new List<Route>();
            if (date.Equals("HOY"))
            {
                var result = await _routes
                    .Include(x => x.CollectionPoints)
                    .Where(x => x.StartDate.Day == today.Day)
                    .ToListAsync();
                foreach (var route in result)
                {
                    filterList.Add(route);
                }
            } else if(date.Equals("SEMANA"))
            {
                var result = await _routes
                    .Include(X => X.CollectionPoints)
                    .Where(x => x.StartDate <= today && 
                x.StartDate >= today.AddDays(-7))
                    .ToListAsync();
                foreach (var route in result)
                {
                    filterList.Add(route);
                }
            } else
            {
                var result = await _routes
                    .Include(X => X.CollectionPoints)
                    .Where(x => x.StartDate <= today &&
                    x.StartDate >= today.AddDays(-30))
                    .ToListAsync();
                foreach (var route in result)
                {
                    filterList.Add(route);
                }
            }
            return filterList;
        }
    }
}
