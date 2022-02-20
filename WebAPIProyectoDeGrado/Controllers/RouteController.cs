using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Services;
using System.Threading.Tasks;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/Routes")]
    public class RouteController: ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDTO<RouteDTO>>> Get(int page, int amount)
        {
            var route = await _routeService.GetAll(page, amount);
            return Ok(route);
        }
    }
}
