using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class PuntoDeRecoleccionService: GenericService<PuntoDeRecoleccion>, IPuntoDeRecoleccionService
    {
        private readonly IPuntoDeRecoleccionRepository puntoDeRecoleccionRepository;

        public PuntoDeRecoleccionService(IPuntoDeRecoleccionRepository puntoDeRecoleccionRepository): base(puntoDeRecoleccionRepository)
        {
            this.puntoDeRecoleccionRepository = puntoDeRecoleccionRepository;
        }
    }
}
