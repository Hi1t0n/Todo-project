using UserService.Domain;

namespace UserService.Host.Routes;

public static class TodoRouter
{
    public static WebApplication AddTodoRouter(this WebApplication app)
    {
        var TodoGroup = app.MapGroup("/api/todos");

        return app;
    }
}
