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
        private readonly IAddressRepository direccionRepository;

        public AddressService(IAddressRepository direccionRepository): base(direccionRepository)
        {
            this.direccionRepository = direccionRepository;
        }
    }
}
