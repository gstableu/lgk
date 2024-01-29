using LGK.Geckos;
using LGK.Library;
using Microsoft.EntityFrameworkCore;

namespace LGK.Geckos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationDbContext>(opt => { 
                opt.UseSqlServer(connectionString);
            });
            services.AddAutoMapper(typeof(Startup));

            services.AddMicroService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMicroServiceConfig(env);
        }
    }
}