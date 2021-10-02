using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");
            }
            _entities.Remove(entity);
            await context.SaveChangesAsync();
        }


        public virtual async Task<List<TEntity>> GetAll()
        {
            List<TEntity> entities = new List<TEntity>();
            var result = await _entities.ToListAsync();
            return result;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _entities.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _entities.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
