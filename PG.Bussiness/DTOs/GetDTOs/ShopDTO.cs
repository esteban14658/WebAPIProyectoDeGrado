using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public string Image { get; set; }
        public List<OrderDto> OrderList { get; set; }
        public AddressDto Address { get; set; }
        public UserDto User { get; set; }
    }
}
