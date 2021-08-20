using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class UserService: GenericService<Usuario>, IUserService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UserService(IUsuarioRepository usuarioRepository): base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
    }
}