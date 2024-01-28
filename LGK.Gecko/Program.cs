using System.Runtime.CompilerServices;
using LGK.Gecko;
using LGK.Library;

namespace LGK.Gecko
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