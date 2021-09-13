using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IRecyclerRepository: IGenericRepository<Recycler>
    { 
        Task<Recycler> GetUserByEmail(string email);
        Task<Recycler> GetUserById(int id);
        bool Exists(int id);
        bool ExistUserByEmail(string email);
        bool ExistUserById(int id);
    }
}
