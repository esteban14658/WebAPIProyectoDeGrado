using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        bool ExistsByEmail(string email);
    }
}
