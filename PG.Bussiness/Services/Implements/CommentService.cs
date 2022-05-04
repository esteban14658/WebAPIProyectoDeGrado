using AutoMapper;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Models.Entitys;
using PG.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;
using WebAPIProyectoDeGrado.Services.Implements;

namespace PG.Bussiness.Services.Implements
{
    public class CommentService : GenericService<CommentDto, CreateCommentDto, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository) : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task DeleteAll(int idUser)
        {
            var existsUser = _userRepository.isExists(idUser);
            if (existsUser.Result == false)
            {
                throw new KeyNotFoundException("Not found user");
            }
            var list = await _commentRepository.GetAllByIdUser(idUser);
            foreach (var item in list)
            {
                await _commentRepository.Delete(item.Id);
            }
        }

        public async Task<List<CommentDto>> Get(int idUser)
        {
            var genericList = await _commentRepository.GetAllByIdUser(idUser);
            var listMapped = new List<CommentDto>();
            foreach (var item in genericList)
            {
                var mapping = _mapper.Map<CommentDto>(item);
                listMapped.Add(mapping);
            }
            return listMapped;
        }

        public override Task<CreateCommentDto> Insert(CreateCommentDto dto)
        {
            var existsUser = _userRepository.isExists(dto.UserId);
            if (existsUser.Result == false)
            {
                throw new KeyNotFoundException("Not found user");
            }
            dto.Date = DateTime.Now.ToUniversalTime().AddHours(-5);
            return base.Insert(dto);
        }


    }
}
