using LGK.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LGK.Gecko;

public class ApplicationDbContext : CustomDbContext
{
    public DbSet<User> User { get; set; }
    public ApplicationDbContext() : base(StartupExtensions.GetAssemblyName())
    {
        
    }

}