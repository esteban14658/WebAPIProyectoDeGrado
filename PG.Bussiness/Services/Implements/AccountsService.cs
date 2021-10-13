using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PG.Bussiness.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using PG.Bussiness.Exceptions;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.Services.Implements
{
    public class AccountsService: IAccountsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsService(IUserRepository userRepository, IMapper mapper, UserManager<IdentityUser> userManager,
            IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse> Register(CreateUserDTO createUser, string entry, string aux)
        {
            var user = new IdentityUser
            {
                UserName = createUser.Email,
                Email = createUser.Email
            };
            var result = await userManager.CreateAsync(user, createUser.Password);
            var userAux = await userManager.FindByEmailAsync(createUser.Email);
            await userManager.AddClaimAsync(userAux, new Claim(entry,aux));
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
    }
}
