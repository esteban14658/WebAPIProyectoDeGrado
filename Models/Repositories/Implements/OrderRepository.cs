using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
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

        public bool Exists(int id)
        {
            return _order.Any(x => x.Id.Equals(id));
        }

        public override async Task<Order> Update(Order entity)
        {
            var query = from o in _context.Orders
                        where o.Id == entity.Id
                        select o;
            foreach (var item in query)
            {
                item.TypeOfMaterial = entity.TypeOfMaterial;
                item.Price = entity.Price;
            }
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
