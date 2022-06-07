using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override async Task<List<CollectionPoint>> GetAll()
        {
            var result = await _collectionPoints.Include(x =>
                x.Address).ToListAsync();
            return result;
        }

        public async Task<List<CollectionPoint>> GetByState(string state)
        {
            var get = await _collectionPoints.Where(x => x.State.Equals(state)).
                Include(x => x.Address).ToListAsync();
            return get;
        }

        public override async Task<CollectionPoint> GetById(int id)
        {
            var result = await _collectionPoints.Include(x => x.Address).
                FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public bool Exists(int id)
        {
            return _collectionPoints.Any(x => x.Id == id);
        }

        public async Task<List<CollectionPoint>> GetByTypeOfMaterial(string typeOfMaterial)
        {
            var result = await _collectionPoints.Where(x => x.TypeOfMaterial.Equals(typeOfMaterial)).
                Include(x => x.Address).ToListAsync();
            return result;
        }

        public async Task<List<CollectionPoint>> GetByDate()
        {
            var result = await _collectionPoints.OrderByDescending(x => x.CreateDate).
                Include(x => x.Address).ToListAsync();
            return result;
        }

        public async Task<CollectionPoint> Update(CollectionPoint entity, string stateCompare)
        {
            var query = from c in _context.CollectionPoints
                        where c.Id == entity.Id
                        select c;
            foreach (CollectionPoint c in query)
            {
                if (stateCompare.Equals(c.State))
                {
                    c.RouteId = entity.RouteId;
                    c.TypeOfMaterial = entity.TypeOfMaterial;
                    c.State = entity.State;
                }
                else
                {
                    throw new DbUpdateException("You are trying to send a status different from the one found in the database");
                }

            }
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<List<CollectionPoint>> GetByIdResident(int id, string state)
        {
            var query = from c in _context.CollectionPoints
                        where (id == c.Resident)
                        && (c.State.Equals(state))
                        select c;

            var result = query.Include(x => x.Address).ToListAsync();
            return result;
        }

        public async Task<List<CollectionPoint>> GetByStateAndType(string state, string type)
        {
            var result = await _collectionPoints.Where(x => x.TypeOfMaterial.Equals(type))
                .Where(x => x.State.Equals(state))
                .OrderByDescending(x => x.CreateDate)
                .Include(x => x.Address).ToListAsync();
            return result;
        }

        public Task<List<CollectionPoint>> GetByIdRoute(int idRoute, string state)
        {
            var query = from c in _context.CollectionPoints
                        where (idRoute == c.RouteId)
                        && (c.State.Equals(state))
                        select c;

            var result = query.Include(x => x.Address).ToListAsync();
            return result;
        }

        public async Task<List<CollectionPoint>> GetByDate(string date)
        {
            var filterList = new List<CollectionPoint>();
            if (date.Equals("HOY"))
            {
                var result = await _collectionPoints.Where(x => x.CreateDate.Day == DateTime.Now.Day)
                    .ToListAsync();
                foreach (var route in result)
                {
                    filterList.Add(route);
                }
            }
            else if (date.Equals("SEMANA"))
            {
                var result = await _collectionPoints.Where(x => x.CreateDate <= DateTime.Now &&
                x.CreateDate >= DateTime.Now.AddDays(-7))
                    .ToListAsync();
                foreach (var route in result)
                {
                    filterList.Add(route);
                }
            }
            else
            {
                var result = await _collectionPoints.Where(x => x.CreateDate <= DateTime.Now &&
                x.CreateDate >= DateTime.Now.AddDays(-30))
                    .ToListAsync();
                foreach (var route in result)
                {
                    filterList.Add(route);
                }
            }
            return filterList;
        }

        public async Task Disassociate()
        {
            DateTime today = DateTime.Now.ToUniversalTime().AddHours(-5);
            DateTime aux = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            var listAll =  from c in _context.CollectionPoints
                            where (c.CreateDate < aux) &&
                            (c.State.Equals("Activo"))
                            select c;
            foreach (var item in listAll)
            {
                item.State = "Espera";
                item.RouteId = null;
            }
            await _context.SaveChangesAsync();
        }
    }
}
