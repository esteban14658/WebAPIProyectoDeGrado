using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class CollectionPointService: GenericService<PuntoDeRecoleccion>, ICollectionPointService
    {
        private readonly IPuntoDeRecoleccionRepository puntoDeRecoleccionRepository;

        public CollectionPointService(IPuntoDeRecoleccionRepository puntoDeRecoleccionRepository): base(puntoDeRecoleccionRepository)
        {
            this.puntoDeRecoleccionRepository = puntoDeRecoleccionRepository;
        }
    }
}
