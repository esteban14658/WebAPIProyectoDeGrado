using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface IRouteService : IGenericService<RouteDto, CreateRouteDto>
    {
        Task<int> Finalize(int id);
        Task<RouteDto> InsertCustom(CreateRouteDto dto);
        Task AddCommentToRoute(int idRoute, CreateCommentDto dto);
        Task<List<RouteDto>> GetByIdRecycler(int idRecycler);
    }
}