using AutoMapper;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Models.Entitys;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Utilitys
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // DTOs para recibir informacion

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Recycler, RecyclerDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Resident, ResidentDTO>().ReverseMap();
            CreateMap<CollectionPoint, CollectionPointDTO>().ReverseMap();
            CreateMap<Shop, ShopDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Route, RouteDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();


            // **** *** **************************************************

            // DTOs para enviar informacion

            CreateMap<CreateRecyclerDTO, Recycler>().ReverseMap();
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<CreateAddressDTO, Address>().ReverseMap();
            CreateMap<CreateCollectionPointDTO, CollectionPoint>().ReverseMap();
            CreateMap<CreateResidentDTO, Resident>().ReverseMap();
            CreateMap<CreateShopDTO, Shop>().ReverseMap();
            CreateMap<CreateRouteDTO, Route>().ReverseMap();
            CreateMap<CreateCommentDTO, Comment>().ReverseMap();
            CreateMap<CreateOrderDTO, Order>().ReverseMap();


            CreateMap<CreateRecyclerDTO, RecyclerDTO>().ReverseMap();
            CreateMap<CreateUserDTO, UserDTO>().ReverseMap();
            CreateMap<CreateAddressDTO, AddressDTO>().ReverseMap();
            CreateMap<CreateCollectionPointDTO, CollectionPointDTO>().ReverseMap();
            CreateMap<CreateResidentDTO, ResidentDTO>().ReverseMap();
            CreateMap<CreateShopDTO, ShopDTO>().ReverseMap();

            CreateMap<CollectionPoint, CollectionPointUpdateDTO>().ReverseMap();
        }
    }
}
