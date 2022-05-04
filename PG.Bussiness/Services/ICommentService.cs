using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface ICommentService : IGenericService<CommentDto, CreateCommentDto>
    {
        Task DeleteAll(int id);
        Task<List<CommentDto>> Get(int idUser);
    }
}
