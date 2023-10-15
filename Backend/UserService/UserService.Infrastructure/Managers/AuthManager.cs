using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Helpers;


namespace UserService.Infrastructure.Managers
{

    public class AuthManager : IAuthManager
    {
        private UserContext _UserContext;

        public AuthManager(UserContext userContext)
        {
            _UserContext = userContext;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="_login">логин пользователя</param>
        /// <param name="password">пароль пользователя</param>
        /// <returns></returns>
        public object Login(string _login, string password)
        {
            if(_login.Length is 0 && password.Length is 0) { throw new Exception("Данные не могут быть пустыми"); }
            User? user = _UserContext.Users.FirstOrDefault(x => x.Login == _login && x.Password == password);
            if (user is null) { throw new Exception("Вы не зарегистрированны"); }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };

            // генерация токена
            var jwt = new JwtSecurityToken(
                issuer: JwtBearerTokenOptions.ISSUER,
                audience: JwtBearerTokenOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(JwtBearerTokenOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Ответ
            var response = new
            {
                access_token = encodedJwt,
                login = user.Login
            };

            return response;
        }
    }
}