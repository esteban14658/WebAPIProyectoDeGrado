using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class PuntoDeRecoleccionRepository: GenericRepository<PuntoDeRecoleccion>, IPuntoDeRecoleccionRepository
    {
        public PuntoDeRecoleccionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
