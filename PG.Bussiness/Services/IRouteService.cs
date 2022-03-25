using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface IRouteService : IGenericService<RouteDTO, CreateRouteDTO>
    {
        Task<RouteDTO> Finalize(RouteDTO routeDTO, int id);
        Task<RouteDTO> InsertCustom(CreateRouteDTO dto);
        Task AddCommentToRoute(int idRoute, CreateCommentDTO dto);
    }
}
