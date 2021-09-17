using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class ResidentRepository: GenericRepository<Resident>, IResidentRepository
    {
        private readonly DbSet<Resident> _resident;
        private readonly ApplicationDbContext _context;
        public ResidentRepository(ApplicationDbContext context): base(context)
        {
            _resident = context.Set<Resident>();
            _context = context;
        }

        public bool Exists(int id)
        {
            return _resident.Any(x => x.Id == id);
        }

        public bool ExistUserByEmail(string email)
        {
            return _resident.Any(x => x.User.Email.Equals(email));
        }

        public bool ExistUserById(int id)
        {
            return _resident.Any(x => x.User.Id == id);
        }

        public override async Task<Resident> GetById(int id)
        {
            return await _resident.Include(x => x.User).Include(x => x.AddressList)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Resident>> GetAll()
        {
            var result = await _resident.Include(x => x.User).Include(x =>
                x.AddressList).ToListAsync();
            return result;
        }

        public override async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");
            }
            _resident.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Resident> GetUserByEmail(string email)
        {
            return await _resident.Include(x => x.User).Include(x => x.AddressList)
                .FirstOrDefaultAsync(x => x.User.Email == email);
        }

        public async Task<Resident> GetUserById(int id)
        {
            return await _resident.Include(x => x.User).Include(x => x.AddressList)
                .FirstOrDefaultAsync(x => x.User.Id == id);
        }
    }
}
