using CQRS.Application.Exceptions;
using CQRS.Application.InterfaceContracts.Identity;
using CQRS.Application.Models.Identity;
using CQRS.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Identity.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSetting _options;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSetting> options, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _options = options.Value;
            _signInManager = signInManager;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found", request.Email);
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //  _userManager.CheckPasswordAsync
            if (!result.Succeeded)
            {
                throw new BadRequestException($"Incorrect password");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        // Microsoft.AspNetCore.Authentication.JwtBearer require jwt key > 256 bits
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _options.Issuer,
               audience: _options.Audience,
               claims: claims,
               expires: DateTime.Now.AddHours(_options.DurationMinute),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }
    }
}
