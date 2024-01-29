using LGK.Geckos.Models;
using LGK.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LGK.Geckos;

public class ApplicationDbContext : CustomDbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Gecko> Gecko { get; set; }
    public DbSet<Morph> Morphs { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

}