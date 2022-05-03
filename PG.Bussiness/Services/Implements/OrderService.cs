using AutoMapper;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Services;
using PG.Models.Entitys;
using PG.Models.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class OrderService : GenericService<OrderDTO, CreateOrderDTO, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderDTO>> AddOrderToShop(int idShop, List<OrderDTO> orderList)
        {
            List<Order> orders = new();
            foreach (var item in orderList)
            {
                var order = _mapper.Map<Order>(item);
                orders.Add(order);
            }
            await _orderRepository.AddOrderToShop(idShop, orders);
            return orderList;
        }

        public async override Task<OrderDTO> Update(OrderDTO dto, int id)
        {
            var exists = _orderRepository.Exists(id);
            if (!exists)
            {
                throw new KeyNotFoundException("Doesn´t exists");
            }
            var mapped = _mapper.Map<Order>(dto);
            mapped.Id = id;
            await _orderRepository.Update(mapped);
            return dto;
        }
    }
}
