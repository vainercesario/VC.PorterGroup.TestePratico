using Serilog;
using VC.PorterGroup.TestePratico;

namespace VC.PorterGroup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = CreateConfiguration();
            CreateHostBuilder(args, configuration).Build().Run();
        }

        private static IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}