using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ResidenteService: GenericService<Residente>, IResidenteService
    {
        private readonly IResidenteRepository residenteRepository;

        public ResidenteService(IResidenteRepository residenteRepository): base(residenteRepository)
        {
            this.residenteRepository = residenteRepository;
        }
    }
}
