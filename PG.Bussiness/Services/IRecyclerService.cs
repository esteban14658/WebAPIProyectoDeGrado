using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IRecyclerService: IGenericService<RecyclerDTO>
    {
        Task<RecyclerDTO> GetUserByEmail(string email);
    }
}
