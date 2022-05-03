using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/Comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCommentDTO createCommentDTO)
        {
            var result = await _commentService.Insert(createCommentDTO);
            return Created("", result);
        }

        [HttpDelete("{idUser:int}")]
        public async Task<ActionResult> Delete(int idUser)
        {
            await _commentService.DeleteAll(idUser);
            return NoContent();
        }

        [HttpGet("{idUser:int}")]
        public async Task<ActionResult<List<CommentDTO>>> Get(int idUser)
        {
            var result = await _commentService.Get(idUser);
            return Ok(result);
        }
    }
}
