using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Datos.Models;
using Datos.Helpers;

namespace Inicio.Services
{
    public interface IUserService
    {
        LoginModel Authenticate(string username, string password);
        IEnumerable<LoginModel> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        /*private List<LoginModel> _users = new List<LoginModel>
        { 
            new LoginModel { Username = "test", Password = "test" } 
        };*/

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /*public LoginModel Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }
        
        public IEnumerable<LoginModel> GetAll()
        {
            return _users.WithoutPasswords();
        }
        */
        LoginModel IUserService.Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LoginModel> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}