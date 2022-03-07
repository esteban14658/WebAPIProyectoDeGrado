using PG.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Models.Repositories
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Task<List<Order>> AddOrderToShop(int idShop, List<Order> orderList);
    }
}
