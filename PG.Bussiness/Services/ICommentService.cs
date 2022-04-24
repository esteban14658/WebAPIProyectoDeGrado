using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Bussiness.Services
{
    public interface ICommentService : IGenericService<CommentDTO, CreateCommentDTO>
    {
        Task DeleteAll(int id);
        Task<List<CommentDTO>> Get(int idUser);
    }
}
