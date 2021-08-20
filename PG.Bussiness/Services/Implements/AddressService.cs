using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class AddressService: GenericService<Address>, IAddressService
    {
        private readonly IDireccionRepository direccionRepository;

        public AddressService(IDireccionRepository direccionRepository): base(direccionRepository)
        {
            this.direccionRepository = direccionRepository;
        }
    }
}
