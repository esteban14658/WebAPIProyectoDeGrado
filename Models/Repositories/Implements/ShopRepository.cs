using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        private readonly DbSet<Shop> _shop;
        private readonly ApplicationDbContext _context;

        public ShopRepository(ApplicationDbContext context) : base(context)
        {
            _shop = context.Set<Shop>();
            _context = context;
        }

        public async Task DeleteAddress(int idShop)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x =>
                x.ShopId == idShop);
            if (address == null)
            {
                
            }
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int idShop)
        {
            var shop = await _shop.Include(x => 
            x.User).FirstOrDefaultAsync(x => x.Id == idShop);
            var user = await _context.UsersApp.FirstOrDefaultAsync(x => 
                x.Id == shop.User.Id);
            _context.UsersApp.Remove(user);
            await _context.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            return _shop.Any(x => x.Id == id);
        }

        public bool ExistUserByEmail(string email)
        {
            return _shop.Any(x => x.User.Email.Equals(email));
        }

        public override async Task<List<Shop>> GetAll()
        {
            var result = await _shop.Include(x => x.User).Include(x =>
                x.Address).ToListAsync();
            return result;
        }

        public override async Task<Shop> GetById(int id)
        {
            var result = await _shop.Include(x => x.User).Include(x =>
                x.Address).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        
    }
}
