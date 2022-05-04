using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Models.Entitys;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.Services
{
    public interface IAccountsService
    {
        Task<AuthenticationResponse> Register(CreateUserDto createUser, string entry, string aux);
        Task<AuthenticationResponse> Login(UserCredentials userCredentials);
        Task<string> SendConfirmEmail();
        Task<Code> ConfirmEmail(string email, string code);
        Task<string> SendPasswordChangeCode(string email);
        Task<int> ChangePassword(CreateUserDto createUser, string code);
        Task DoAdmin(EditAdminDto editAdminDTO);
        string HashPassword(CreateUserDto createUser);
    }
}
