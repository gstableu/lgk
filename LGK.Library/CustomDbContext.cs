using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace LGK.Library;
public abstract class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions options) : base(options)
    {

    }
   
}