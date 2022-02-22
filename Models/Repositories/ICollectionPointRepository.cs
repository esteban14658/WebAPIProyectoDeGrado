﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface ICollectionPointRepository : IGenericRepository<CollectionPoint>
    {
        Task<List<CollectionPoint>> GetByState(string state);
        bool Exists(int id);
    }
}
