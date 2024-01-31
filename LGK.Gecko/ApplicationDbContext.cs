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
    public DbSet<GeckoMorph> GeckoMorphs { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gecko>()
                    .ApplyEntityDefault();
        modelBuilder.Entity<GeckoMorph>()
                    .ApplyEntityDefault();
        modelBuilder.Entity<Morph>()
                    .ApplyEntityDefault();
    }

}