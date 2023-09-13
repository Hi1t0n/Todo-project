using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Managers;

namespace UserService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавялем бизнес логику
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    private static IServiceCollection AddBusinessLogic(this IServiceCollection services,IConfiguration configuration,string connectionString)
    {
        services.AddManagers();
        services.AddDataBase(connectionString);
        return services;
    }

    /// <summary>
    /// Добавляем Managers
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IUserManager,UserManager>();
        services.AddScoped<ITodoManager,TodoManager>();
        return services;
    }

    /// <summary>
    /// Добавляем БД
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Строка подключения</param>
    /// <returns></returns>
    private static IServiceCollection AddDataBase(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<UserContext>(builder => builder.UseNpgsql(connectionString));
        services.AddDbContext<TodoContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }
}
