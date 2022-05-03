using PG.Models.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Models.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        bool Exists(int id);
        Task<List<Order>> AddOrderToShop(int idShop, List<Order> orderList);
    }
}
