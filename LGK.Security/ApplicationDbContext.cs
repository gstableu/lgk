using Microsoft.EntityFrameworkCore;

namespace LGK.Security;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public ApplicationDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
}

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}