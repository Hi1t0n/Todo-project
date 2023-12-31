﻿using UserService.Domain;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Contexts;

public sealed class TodoContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
        Database.Migrate();
    }
}
