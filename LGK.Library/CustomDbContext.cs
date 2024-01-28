using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace LGK.Library;

public abstract class CustomDbContext : DbContext
{

    public CustomDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = new SqlConnectionStringBuilder();
        connectionString.DataSource = "localhost";
        connectionString.UserID = "sa";
        connectionString.Password = "SQLPWD=PWD";
        connectionString.TrustServerCertificate = true;
        connectionString.InitialCatalog = "DB." +  StartupExtensions.GetAssemblyName();
        options.UseSqlServer(connectionString.ConnectionString);
    }
}