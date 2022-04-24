using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface IRouteService : IGenericService<RouteDTO, CreateRouteDTO>
    {
        Task<int> Finalize(int id);
        Task<RouteDTO> InsertCustom(CreateRouteDTO dto);
        Task AddCommentToRoute(int idRoute, CreateCommentDTO dto);
        Task<List<RouteDTO>> GetByIdRecycler(int idRecycler);
    }
}