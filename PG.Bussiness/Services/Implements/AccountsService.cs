using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Bussiness.Exceptions;
using PG.Models.Entitys;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Repositories;

namespace PG.Bussiness.Services.Implements
{
    public class AccountsService : IAccountsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public AccountsService(IUserRepository userRepository, IMapper mapper, UserManager<IdentityUser> userManager,
            IConfiguration configuration, SignInManager<IdentityUser> signInManager, IEmailSender emailSender, IUserStore<IdentityUser> userStore,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            _userRepository = userRepository;
            _emailSender = emailSender;
            _context = context;
        }

        public async Task<AuthenticationResponse> Register(CreateUserDTO createUser, string entry, string aux)
        {
            var user = new IdentityUser
            {
                UserName = createUser.Email,
                Email = createUser.Email
            };
            await userManager.CreateAsync(user, createUser.Password);

            string code = await SendConfirmEmail();
            //           var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await _emailSender.SendEmailAsync(user.Email, "Confirm your email", code);

            //           await userManager.ConfirmEmailAsync(user, token);
            var userAux = await userManager.FindByEmailAsync(createUser.Email);
            await userManager.AddClaimAsync(userAux, new Claim(entry, aux));
            return null;
        }

        public async Task<AuthenticationResponse> Login(UserCredentials userCredentials)
        {
            var consult = await _userRepository.GetByEmail(userCredentials.Email);

            var result = await signInManager.PasswordSignInAsync(userCredentials.Email,
                userCredentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var send = _mapper.Map<CreateUserDTO>(consult);
                return await BuildToken(send);
            }
            else
            {
                throw new AppException("Incorrect Login");
            }
        }

        private async Task<AuthenticationResponse> BuildToken(CreateUserDTO createUser)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", createUser.Email),
                new Claim("role", createUser.Role)
            };
            var user = await userManager.FindByEmailAsync(createUser.Email);
            var claimsDB = await userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyJwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddYears(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };
        }

        public async Task DoAdmin(EditAdminDTO editAdminDTO)
        {
            var user = await userManager.FindByEmailAsync(editAdminDTO.Email);
            await DeleteAllRoles(user);
            await userManager.AddClaimAsync(user, new Claim("isResident", "1"));
            await userManager.AddClaimAsync(user, new Claim("isRecycler", "2"));
            await userManager.AddClaimAsync(user, new Claim("isAdmin", "3"));
            await userManager.AddClaimAsync(user, new Claim("isShop", "4"));
            var query = from a in _context.UsersApp
                        where a.Email == editAdminDTO.Email
                        select a;
            foreach (var a in query)
            {
                a.Role = "Administrador";
            }
            _context.SaveChanges();

        }

        private async Task DeleteAllRoles(IdentityUser user)
        {
            await userManager.RemoveClaimAsync(user, new Claim("isResident", "1"));
            await userManager.RemoveClaimAsync(user, new Claim("isRecycler", "2"));
            await userManager.RemoveClaimAsync(user, new Claim("isAdmin", "3"));
            await userManager.RemoveClaimAsync(user, new Claim("isShop", "4"));
        }

        public string HashPassword(CreateUserDTO createUser)
        {
            var user = new IdentityUser
            {
                UserName = createUser.Email,
                Email = createUser.Email
            };
            string userPass = userManager.PasswordHasher.HashPassword(user, createUser.Password);
            return userPass;
        }

        public async Task<Code> ConfirmEmail(string email, string code)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };
            var query = await _context.Codes.Where(x => x.Date > DateTime.Now).ToListAsync();
            var filter = query.FirstOrDefault(x => x.UserCode.Equals(code));
            if (filter == null)
            {
                throw new KeyNotFoundException("The code is not registered or expired");
            }
            else
            {
                var query2 = from r in _context.Users
                             where r.Email == email
                             select r;
                foreach (var item in query2)
                {
                    item.EmailConfirmed = true;
                }
                await _context.SaveChangesAsync();
            }
            return filter;
        }

        public async Task<string> SendConfirmEmail()
        {
            Code code = new Code();
            Guid guid = Guid.NewGuid();
            code.UserCode = guid.ToString().Substring(startIndex: 0, length: 6);
            code.Date = DateTime.Now.AddHours(value: 2);
            _context.Codes.Add(code);
            await _context.SaveChangesAsync();
            return code.UserCode;
        }

        public async Task<string> SendPasswordChangeCode(string email)
        {
            Code code = new Code();
            Guid guid = Guid.NewGuid();
            code.UserCode = guid.ToString().Substring(startIndex: 0, length: 6);
            code.Date = DateTime.Now.AddHours(value: 2);
            _context.Codes.Add(code);
            await _context.SaveChangesAsync();
            await _emailSender.SendEmailAsync(email, "Tu codigo para resetear el password", code.UserCode);
            return code.UserCode;
        }

        public async Task<int> ChangePassword(CreateUserDTO createUser, string code)
        {
            var query = await _context.Codes.Where(x => x.Date > DateTime.Now).ToListAsync();
            var filter = query.FirstOrDefault(x => x.UserCode.Equals(code));
            if (filter == null)
            {
                throw new KeyNotFoundException("The code is not registered or expired");
            }
            else
            {
                var passHash = HashPassword(createUser);
                var query2 = from r in _context.Users
                             where r.Email == createUser.Email
                             select r;
                foreach (var item in query2)
                {
                    item.PasswordHash = passHash;
                }
                await _context.SaveChangesAsync();
            }
            return query.Count();
        }
    }
}
