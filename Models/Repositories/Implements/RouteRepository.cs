using PG.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.Repositories.Implements;

namespace PG.Models.Repositories.Implements
{
    public class RouteRepository: GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
