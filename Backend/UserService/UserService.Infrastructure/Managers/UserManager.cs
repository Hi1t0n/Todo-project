using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Helpers;

namespace UserService.Infrastructure.Managers;

public class UserManager : IUserManager
{
    private UserContext _UserContext;

    public UserManager(UserContext context)
    {
        _UserContext = context;
    }

    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <returns>Список всех пользователей</returns>
    public List<User> GetAllUsers()
    {
       return _UserContext.Users.ToList();
    }


    /// <summary>
    /// Получение данных пользователя по id
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Данные пользователя</returns>
    public User? GetUserById(long id) 
    {
        return _UserContext.Users.FirstOrDefault(x => x.Id == id);
    }

    public User CreateUser(User user)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x=>x.Login == user.Login);

        if (existingUser is not null) { throw new Exception("Данный логин уже занят!"); }

        user.Password = HashPassword.PasswordHash(user.Password);

        var UserData = _UserContext.Users.Add(user);

        _UserContext.SaveChanges();

        return UserData.Entity;
    }

    public User? UpdateUser(User user)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x=>x.Id == user.Id);

        if (existingUser is null) { return null; }

        //existingUser.Login = user.Login;
        //existingUser.Password = user.Password;
        //existingUser.Email = user.Email;
        //existingUser.EmailConfirmed = user.EmailConfirmed;
        //existingUser.PhoneConfirmed = user.PhoneConfirmed;
        //existingUser.NickName = user.NickName;
        //existingUser.PhoneNumber = user.PhoneNumber;
        //existingUser.TodoList = user.TodoList;

        _UserContext.Entry(existingUser).CurrentValues.SetValues(user);

        _UserContext.SaveChanges();

        return existingUser;
    }

    public User? DeleteUser(long id)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x=>x.Id == id);
        if (existingUser is null) { return null; }
        var UserData = _UserContext.Remove(existingUser);
        _UserContext.SaveChanges();
        return UserData.Entity;
    }


}


