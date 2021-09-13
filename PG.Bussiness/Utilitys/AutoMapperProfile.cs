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

            CreateMap<CreateRecyclerDTO, Recycler>().ReverseMap();
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<CreateAddressDTO, Address>().ReverseMap();
            CreateMap<CreateCollectionPointDTO, CollectionPoint>().ReverseMap();
            CreateMap<CreateResidentDTO, Resident>().ReverseMap();
            CreateMap<CreateShopDTO, Shop>().ReverseMap();

            CreateMap<CreateRecyclerDTO, RecyclerDTO>().ReverseMap();
            CreateMap<CreateUserDTO, UserDTO>().ReverseMap();
            CreateMap<CreateAddressDTO, AddressDTO>().ReverseMap();
            CreateMap<CreateCollectionPointDTO, CollectionPointDTO>().ReverseMap();
            CreateMap<CreateResidentDTO, ResidentDTO>().ReverseMap();
            CreateMap<CreateShopDTO, ShopDTO>().ReverseMap();
        }
    }
}
