using DotNetCorePractice.Data.Entities;
using DotNetCorePractice.Utilities.Exceptions;
using DotNetCorePractice.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace DotNetCorePractice.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _conf;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration conf)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _conf = conf;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return null;
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            
            if (!result.Succeeded)
            {
                return null;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _conf["Jwt:Issuer"],
                audience: _conf["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now,
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
