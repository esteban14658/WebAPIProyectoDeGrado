

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly DbSet<Address> _address;
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _address = context.Set<Address>();
        }

        public override async Task<Address> GetById(int id)
        {
            var address = await _address.FirstOrDefaultAsync(x => x.Id == id);
            return address;
        }

        public async Task<Address> AddAddressToResident(int idResident, Address address)
        {
            var resident = await _context.Residents.FirstOrDefaultAsync(x => x.Id == idResident);
            if (resident == null)
            {
                throw new KeyNotFoundException("the resident is not registered");
            }
            address.Resident = resident;
            _address.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> AddAddressToShop(int idShop, Address address)
        {
            var shop = await _context.Shops.Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == idShop);
            if (shop == null)
            {
                throw new KeyNotFoundException("the shop is not registered");
            }
            if (shop.Address != null)
            {
                return null;
            }
            address.ShopId = idShop;
            _address.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public override async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new KeyNotFoundException("The entity is null");
            }
            _address.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async override Task<Address> Update(Address entity)
        {
            var query = from a in _context.Addresses
                        where a.Id == entity.Id
                        select a;
            foreach (Address a in query)
            {
                a.Neighborhood = entity.Neighborhood;
                a.StreetType = entity.StreetType;
                a.Career = entity.Career;
                a.NumberOne = entity.NumberOne;
                a.NumberTwo = entity.NumberTwo;
                a.Description = entity.Description;
                a.Longitude = entity.Longitude;
                a.Latitude = entity.Latitude;
                a.Resident = entity.Resident;
                a.ShopId = entity.ShopId;
                a.CollectionPointId = entity.CollectionPointId;
            }
            _context.SaveChanges();
            return entity;
        }

        public bool Exists(int id)
        {
            return _address.Any(x => x.Id == id);
        }
    }
}
