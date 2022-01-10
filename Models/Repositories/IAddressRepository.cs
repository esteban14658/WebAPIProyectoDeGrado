using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<Address> AddAddressToResident(int idResident, Address address);
    }
}
