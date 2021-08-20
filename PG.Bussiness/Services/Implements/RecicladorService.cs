using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class RecicladorService: GenericService<Reciclador>, IRecicladorService
    {
        private readonly IRecicladorRepository recicladorRepository;
        public RecicladorService(IRecicladorRepository recicladorRepository): base(recicladorRepository)
        {
            this.recicladorRepository = recicladorRepository;
        }
    }
}
