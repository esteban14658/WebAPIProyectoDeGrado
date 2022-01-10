using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        
    }
}
