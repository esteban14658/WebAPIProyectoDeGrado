using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface IRouteService : IGenericService<RouteDTO, CreateRouteDTO>
    {
    }
}
