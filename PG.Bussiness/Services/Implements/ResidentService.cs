using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ResidentService: GenericService<Resident>, IResidentService
    {
        private readonly IResidentRepository residenteRepository;

        public ResidentService(IResidentRepository residenteRepository): base(residenteRepository)
        {
            this.residenteRepository = residenteRepository;
        }
    }
}
