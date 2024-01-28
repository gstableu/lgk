using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Security;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    var connectionStr = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlServer(connectionStr);
});
var app = builder.Build();

//app.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer());
app.MapGet("/", () => "Hello World!");

app.Run();