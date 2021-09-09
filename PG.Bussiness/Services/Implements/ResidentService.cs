using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class ResidentService: GenericService<ResidentDTO,Resident>, IResidentService
    {
        private readonly IResidentRepository _residenteRepository;
        private readonly IMapper _mapper;

        public ResidentService(IResidentRepository residenteRepository, IMapper mapper): base(residenteRepository, mapper)
        {
            _residenteRepository = residenteRepository;
            _mapper = mapper;
        }
    }
}
