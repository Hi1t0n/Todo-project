using Microsoft.AspNetCore.Mvc;
using UserService.Domain;
using UserService.Infrastructure.Managers;

namespace UserService.Host.Routes
{
    public static class AuthRouter
    {
        public static WebApplication AddAuthRouter(this WebApplication app)
        {
            var authGroup = app.MapGroup("/api/login");

            authGroup.MapPost("/",Login);

            return app;
        }

        private static IResult Login(string login, string password, AuthManager authManager)
        {
            var response = authManager.Login(login, password);
            return response is null ? Results.Unauthorized() : Results.Json(response);
        }
    }
}
