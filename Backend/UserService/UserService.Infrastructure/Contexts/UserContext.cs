using UserService.Domain;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Contexts
{
    public sealed class UserContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UserContext(DbContextOptions options) : base(options) 
        {
            Database.Migrate();
        }
    }
}
