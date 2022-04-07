using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Models.Entitys;
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
        Task<string> SendConfirmEmail();
        Task<Code> ConfirmEmail(string email, string code);
        Task<string> SendPasswordChangeCode(string email);
        Task<int> ChangePassword(CreateUserDTO createUser, string code);
        Task DoAdmin(EditAdminDTO editAdminDTO);
        string HashPassword(CreateUserDTO createUser);
    }
}
