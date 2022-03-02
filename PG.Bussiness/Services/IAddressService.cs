using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace WebAPIProyectoDeGrado.Services
{
    public interface IAddressService : IGenericService<AddressDTO, CreateAddressDTO>
    {
        Task<CreateAddressDTO> AddAddressToResident(int idResident, CreateAddressDTO dto);
        Task<CreateAddressDTO> AddAddressToShop(int idShop, CreateAddressDTO dto);
    }
}
