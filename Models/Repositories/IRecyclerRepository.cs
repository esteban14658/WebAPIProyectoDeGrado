using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IRecyclerRepository: IGenericRepository<Recycler>
    {
        Task<List<Recycler>> GetAllRecyclers();
        Task<Recycler> GetUserByEmail(string email);
    }
}
