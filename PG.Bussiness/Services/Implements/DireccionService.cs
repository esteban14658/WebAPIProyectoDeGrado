using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class DireccionService: GenericService<Direccion>, IDireccionService
    {
        private readonly IDireccionRepository direccionRepository;

        public DireccionService(IDireccionRepository direccionRepository): base(direccionRepository)
        {
            this.direccionRepository = direccionRepository;
        }
    }
}
