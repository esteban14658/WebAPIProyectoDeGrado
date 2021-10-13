using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly DbSet<Address> _addtress;
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _addtress = context.Set<Address>();
            _context = context;
        }

        public override async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");
            }
            _addtress.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
