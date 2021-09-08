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

            CreateMap<User, UserDTO>();
            CreateMap<Recycler, RecyclerDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Resident, ResidentDTO>();
            CreateMap<CollectionPoint, CollectionPointDTO>();
            CreateMap<Shop, ShopDTO>();

            // **** *** **************************************************

            // DTOs para enviar informacion

            CreateMap<CreateRecyclerDTO, Recycler>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<CreateCollectionPoint, CollectionPoint>();
            CreateMap<CreateResidentDTO, Resident>();
            CreateMap<CreateShopDTO, Shop>();

            
        }
    }
}
