using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Infrastructure.Contexts;
//TODO:Сделать TODO Manager
namespace UserService.Infrastructure.Managers;

public class TodoManager : ITodoManager
{
    private TodoContext _TodoContext; 
    private UserContext _UserContext;

    public TodoManager (TodoContext todoContext,UserContext userContext)
    {
        _TodoContext = todoContext;
        _UserContext = userContext;
        
    }

    public Todo AddTodo (Todo todo)
    {
        var existingTodo = todo;

        if (existingTodo != null) { throw new Exception("Введены некорректные данные!");  }

        var TodoData = _TodoContext.Add(todo);

        _TodoContext.SaveChanges();

        return TodoData.Entity;
    }

    public List<Todo>? GetAllTodobyUserId(long Id)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x => x.Id == Id);
        if (existingUser is null) { return null; }
        
        return _UserContext.Users.SelectMany(x=>x.TodoList).ToList();
    }

    public Todo? UpdateTodo(Todo todo) 
    {
        var existingTodo = _TodoContext.Todos.FirstOrDefault(x => x.Id == todo.Id);

        if (existingTodo is null) { return null; }

        existingTodo.Title = todo.Title;
        existingTodo.Description = todo.Description;
        existingTodo.EndDate = todo.EndDate;
        
        var TodoData = _TodoContext.Update(existingTodo);

        _TodoContext.SaveChanges();

        return TodoData.Entity;
    }

    public Todo? GetTodoById(long Id) { return _TodoContext.Todos.FirstOrDefault(x=> x.Id == Id); }

    public Todo? DeleteTodo(long Id)
    {
        var existingTodo = _TodoContext.Todos.FirstOrDefault(x => x.Id == Id);
        if (existingTodo is null) { return null; }
        
        var TodoData = _TodoContext.Remove(existingTodo);

        _TodoContext.SaveChanges();

        return TodoData.Entity;
    }
}
