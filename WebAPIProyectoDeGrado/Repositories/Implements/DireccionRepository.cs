using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class DireccionRepository: GenericRepository<Direccion>, IDireccionRepository
    {
        public DireccionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
