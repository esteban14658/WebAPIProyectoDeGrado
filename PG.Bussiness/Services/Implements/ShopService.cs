using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ShopService: GenericService<Shop>, IShopService
    {
        private readonly IShopRepository tiendaRepository;

        public ShopService(IShopRepository tiendaRepository): base(tiendaRepository)
        {
            this.tiendaRepository = tiendaRepository;
        }
    }
}
