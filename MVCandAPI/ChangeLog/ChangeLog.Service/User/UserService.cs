using ChangeLog.Data;
using ChangeLog.Model.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ChangeLog.Service.User
{
    public class UserService : IUserService
    {

        private readonly IConfiguration _configuration;
        private readonly ChangeLogDbContext dbContext;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            dbContext = new ChangeLogDbContext();
        }

        public string AuthenticateUser(LoginModel login)
        {
            var user = dbContext.UserInfos.Where(user => user.UserName == login.UserName && user.Password == login.Password && user.IsDeleted == false).FirstOrDefault();

            if(user != null)
            {
                return generateJwtToken(user);
            }
            else
            {
                return string.Empty;
            }
        }

        public string AuthenticateUser(string email)
        {
            var user = dbContext.UserInfos.Where(user => user.UserName == email && user.IsDeleted == false).FirstOrDefault();

            if (user != null)
            {
                return generateJwtToken(user);
            }
            else
            {
                return string.Empty;
            }
        }

        public UserInfo GetById(int id)
        {
            return dbContext.UserInfos.Where(user => user.Id == id && user.IsDeleted == false).FirstOrDefault(); 
        }

        private string generateJwtToken(UserInfo user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
