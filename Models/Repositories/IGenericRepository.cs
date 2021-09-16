using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAll(int page, int amount);
        Task<TEntity> GetById(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}
