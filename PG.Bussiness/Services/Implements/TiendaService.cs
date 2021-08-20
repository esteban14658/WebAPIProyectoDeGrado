using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class TiendaService: GenericService<Tienda>, ITiendaService
    {
        private readonly ITiendaRepository tiendaRepository;

        public TiendaService(ITiendaRepository tiendaRepository): base(tiendaRepository)
        {
            this.tiendaRepository = tiendaRepository;
        }
    }
}
