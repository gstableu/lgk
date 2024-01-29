using System.Runtime.CompilerServices;
using LGK.Geckos;
using LGK.Library;

namespace LGK.Geckos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).UseMicroServiceBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}