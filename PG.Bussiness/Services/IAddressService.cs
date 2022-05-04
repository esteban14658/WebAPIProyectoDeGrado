using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IAddressService : IGenericService<AddressDto, CreateAddressDto>
    {
        Task<CreateAddressDto> AddAddressToResident(int idResident, CreateAddressDto dto);
        Task<CreateAddressDto> AddAddressToShop(int idShop, CreateAddressDto dto);
    }
}
