using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IResidentRepository : IGenericRepository<Resident>
    {
        Task<Resident> GetUserByEmail(string email);
        Task<Resident> GetUserById(int id);
        bool Exists(int id);
        bool ExistUserByEmail(string email);
        bool ExistUserById(int id);
    }
}
