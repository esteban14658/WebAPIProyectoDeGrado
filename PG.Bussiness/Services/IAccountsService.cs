using PG.Bussiness.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.Services
{
    public interface IAccountsService
    {
        Task<AuthenticationResponse> Register(CreateUserDTO createUser);
        Task<AuthenticationResponse> Login(UserCredentials userCredentials);
    }
}
