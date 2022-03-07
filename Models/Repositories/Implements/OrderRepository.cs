using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.Repositories;
using WebAPIProyectoDeGrado.Repositories.Implements;

namespace PG.Models.Repositories.Implements
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DbSet<Order> _order;
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _order = context.Set<Order>();
        }
        public async Task<List<Order>> AddOrderToShop(int idShop, List<Order> orderList)
        {
            var shop = await _context.Shops.FirstOrDefaultAsync(x => x.Id == idShop);
            if (shop == null)
            {
                throw new KeyNotFoundException("the shop is not registered");
            }
            foreach (var item in orderList)
            {
                item.ShopId = idShop;
                _order.Add(item);
                await _context.SaveChangesAsync();
            }
            return orderList;
        }

    }
}
