using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ResidentService: GenericService<Residente>, IResidentService
    {
        private readonly IResidenteRepository residenteRepository;

        public ResidentService(IResidenteRepository residenteRepository): base(residenteRepository)
        {
            this.residenteRepository = residenteRepository;
        }
    }
}
