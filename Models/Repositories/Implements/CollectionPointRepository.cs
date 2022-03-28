﻿using Microsoft.EntityFrameworkCore;
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

        public async override Task<CollectionPoint> Update(CollectionPoint entity)
        {
            var query = from c in _context.CollectionPoints
                        where c.Id == entity.Id
                        select c;
            foreach (CollectionPoint c in query)
            {
                c.RouteId = entity.RouteId;
                c.TypeOfMaterial = entity.TypeOfMaterial;
                c.State = entity.State;
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
    }
}
