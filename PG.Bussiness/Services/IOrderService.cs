using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface IOrderService : IGenericService<OrderDto, CreateOrderDto>
    {
        Task<List<OrderDto>> AddOrderToShop(int idShop, List<OrderDto> orderList);
    }
}
