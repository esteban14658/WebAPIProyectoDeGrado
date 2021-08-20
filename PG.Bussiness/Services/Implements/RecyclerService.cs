using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class RecyclerService: GenericService<Reciclador>, IRecyclerService
    {
        private readonly IRecicladorRepository recicladorRepository;
        public RecyclerService(IRecicladorRepository recicladorRepository): base(recicladorRepository)
        {
            this.recicladorRepository = recicladorRepository;
        }
    }
}
