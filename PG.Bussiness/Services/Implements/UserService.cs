using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class UserService: GenericService<User>, IUserService
    {
        private readonly IUserRepository usuarioRepository;

        public UserService(IUserRepository usuarioRepository): base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
    }
}