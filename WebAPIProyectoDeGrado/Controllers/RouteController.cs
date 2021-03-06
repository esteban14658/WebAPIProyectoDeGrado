using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/Routes")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDto<RouteDto>>> Get(int page, int amount)
        {
            var route = await _routeService.GetAll(page, amount);
            return Ok(route);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RouteDto>> Get(int id)
        {
            var route = await _routeService.GetById(id);
            return Ok(route);
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<List<RouteDto>>> GetByDate(string date)
        {
            var route = await _routeService.GetByDate(date);
            return Ok(route);
        }

        [HttpGet("GetByIdRecycler/{idRecycler:int}")]
        public async Task<ActionResult<RouteDto>> GetByIdRecycler(int idRecycler)
        {
            var routes = await _routeService.GetByIdRecycler(idRecycler);
            return Ok(routes);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> Finalize(int id)
        {
            await _routeService.Finalize(id);
            return Accepted(new { id });
        }

        [HttpPost]
        public async Task<ActionResult<RouteDto>> Post(CreateRouteDto dto)
        {
            var getWithId = await _routeService.InsertCustom(dto);
            return Created("", new { id = getWithId.Id });
        }

        [HttpPost("AddCommentToRoute/{idRoute:int}")]
        public async Task<ActionResult> AddCommentToRoute([FromBody] CreateCommentDto dto, int idRoute)
        {
            await _routeService.AddCommentToRoute(idRoute, dto);
            return Ok(new { id = idRoute });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _routeService.Delete(id);
            return Ok();
        }
    }
}
