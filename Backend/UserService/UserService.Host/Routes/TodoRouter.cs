using Microsoft.AspNetCore.Mvc;
using UserService.Domain;

namespace UserService.Host.Routes;

public static class TodoRouter
{
    public static WebApplication AddTodoRouter(this WebApplication app)
    {
        var TodoGroup = app.MapGroup("/api/todos");

        TodoGroup.MapPut("/", UpdateTodo);
        TodoGroup.MapPost("/", AddTodo);
        TodoGroup.MapGet("/", GetAllTodosById);
        TodoGroup.MapGet("/{id:long}", GetTodoById);
        TodoGroup.MapDelete("{id:long}", DeleteTodo);

        return app;
    }

    private static IResult AddTodo([FromBody] Todo todo, [FromServices] ITodoManager todoManager)
    {
        var _todo = todoManager.AddTodo(todo);
        return Results.Ok(_todo);
    }

    private static IResult GetAllTodosById([FromQuery] long id, [FromBody] Todo todo, [FromServices] ITodoManager todoManager)
    {
        var _todo = todoManager.GetAllTodobyUserId(id);
        return _todo is null ? Results.NotFound() : Results.Ok(_todo);
    }

    private static IResult UpdateTodo([FromBody] Todo todo, [FromServices] ITodoManager todoManager)
    {
        var _todo = todoManager.UpdateTodo(todo);
        return Results.Ok(_todo);
    }

    private static IResult GetTodoById([FromRoute] long id, [FromServices] ITodoManager todoManager)
    {
        var _todo = todoManager.GetTodoById(id);
        return _todo is null ? Results.NotFound() : Results.Ok(_todo);
    }

    private static IResult DeleteTodo([FromRoute] long id, [FromServices] ITodoManager todoManager)
    {
        var _todo = todoManager.DeleteTodo(id);
        return _todo is null ? Results.NotFound() : Results.Ok(_todo);
    }
}
