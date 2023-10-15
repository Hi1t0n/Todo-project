using UserService.Domain;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserService.Infrastructure.Helpers;

namespace UserService.Host.Routes;

public static class UserRouter
{
    public static WebApplication AddUserRouter(this WebApplication app)
    {
        var userGroup = app.MapGroup("/api/users");

        userGroup.MapGet("/", GetAllUsers);
        userGroup.MapGet("/{id:long}", [Authorize] ()=> GetUserById);
        userGroup.MapPost("/", CreateUser);
        userGroup.MapPut("/" , [Authorize]()=> UpdateUser);
        userGroup.MapDelete("/{id:long}", DeleteUser);
        

        return app;
    }

    private static IResult GetAllUsers(IUserManager userManager)
    {
        var users = userManager.GetAllUsers();
        return Results.Ok(users);
    }

    private static IResult GetUserById(long id, IUserManager userManager) 
    {
        var user = userManager.GetUserById(id);

        return user is null ? Results.NotFound() : Results.Ok(user);
    }

    private static IResult CreateUser(User user, IUserManager userManager) 
    {
        var _user = userManager.CreateUser(user);
        return Results.Ok(_user);
    }

    private static IResult UpdateUser(User user,IUserManager userManager)
    {
        var _user = userManager.UpdateUser(user);
        return _user is null ? Results.NotFound() : Results.Ok(_user);
    }

    private static IResult DeleteUser (long id, IUserManager userManager)
    {
        var user = userManager.DeleteUser(id);
        return user is null ? Results.NotFound() : Results.Ok(user);
    }



}


