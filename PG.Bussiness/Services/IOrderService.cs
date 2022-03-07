using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface IOrderService: IGenericService<OrderDTO, CreateOrderDTO>
    {
        Task<List<OrderDTO>> AddOrderToShop(int idShop, List<OrderDTO> orderList);
    }
}
