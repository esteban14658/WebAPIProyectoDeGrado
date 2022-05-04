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

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Recycler, RecyclerDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Resident, ResidentDto>().ReverseMap();
            CreateMap<CollectionPoint, CollectionPointDto>().ReverseMap();
            CreateMap<Shop, ShopDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Route, RouteDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();


            // **** *** **************************************************

            // DTOs para enviar informacion

            CreateMap<CreateRecyclerDto, Recycler>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<CreateCollectionPointDto, CollectionPoint>().ReverseMap();
            CreateMap<CreateResidentDto, Resident>().ReverseMap();
            CreateMap<CreateShopDto, Shop>().ReverseMap();
            CreateMap<CreateRouteDto, Route>().ReverseMap();
            CreateMap<CreateCommentDto, Comment>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap();


            CreateMap<CreateRecyclerDto, RecyclerDto>().ReverseMap();
            CreateMap<CreateUserDto, UserDto>().ReverseMap();
            CreateMap<CreateAddressDto, AddressDto>().ReverseMap();
            CreateMap<CreateCollectionPointDto, CollectionPointDto>().ReverseMap();
            CreateMap<CreateResidentDto, ResidentDto>().ReverseMap();
            CreateMap<CreateShopDto, ShopDto>().ReverseMap();

            CreateMap<CollectionPoint, CollectionPointUpdateDto>().ReverseMap();
            CreateMap<Shop, ShopUpdateDto>().ReverseMap();
        }
    }
}
