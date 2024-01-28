using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace LGK.Library;

public abstract class CustomDbContext : DbContext
{

    protected readonly string _dbName;
    public CustomDbContext(string dbName)
    {
        _dbName = dbName;
    }
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
        connectionString.InitialCatalog = "LK.Gecko";
        options.UseSqlServer(connectionString.ConnectionString);
    }
}