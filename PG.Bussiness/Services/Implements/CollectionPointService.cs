using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class CollectionPointService: GenericService<CollectionPoint>, ICollectionPointService
    {
        private readonly ICollectionPointRepository puntoDeRecoleccionRepository;

        public CollectionPointService(ICollectionPointRepository puntoDeRecoleccionRepository): base(puntoDeRecoleccionRepository)
        {
            this.puntoDeRecoleccionRepository = puntoDeRecoleccionRepository;
        }
    }
}
