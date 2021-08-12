using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class ResidenteRepository: GenericRepository<Residente>, IResidenteRepository
    {
        public ResidenteRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
