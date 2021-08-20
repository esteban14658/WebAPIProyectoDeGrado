using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Utilitys
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // DTOs para recibir informacion

            CreateMap<Usuario, UserDTO>();
            CreateMap<Reciclador, RecyclerDTO>();
            CreateMap<Direccion, AddressDTO>();
            CreateMap<Residente, ResidentDTO>();
            CreateMap<PuntoDeRecoleccion, CollectionPointDTO>();
            CreateMap<Tienda, ShopDTO>();

            // **** *** **************************************************

            // DTOs para enviar informacion

            CreateMap<CreateRecyclerDTO, Reciclador>();
            CreateMap<CreateUserDTO, Usuario>();
            CreateMap<CreateAddressDTO, Direccion>();
            CreateMap<CreateCollectionPoint, PuntoDeRecoleccion>();
            CreateMap<CreateResidentDTO, Residente>();
            CreateMap<CreateShopDTO, Tienda>();
        }
    }
}
