using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class ShopRepository: GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
