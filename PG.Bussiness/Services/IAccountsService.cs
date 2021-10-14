using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
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
        Task<AuthenticationResponse> Register(CreateUserDTO createUser, string entry, string aux);
        Task<AuthenticationResponse> Login(UserCredentials userCredentials);
        Task DoAdmin(EditAdminDTO editAdminDTO);
    }
}
