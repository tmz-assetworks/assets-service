using Serilog;
using Serilog.Events;

namespace AssetsService.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
          .Enrich.FromLogContext()
          .WriteTo.File("Log//log.txt", rollingInterval: RollingInterval.Day)
          //.WriteTo.Seq("http://localhost:5341")
          .CreateLogger();

            CreateHostBuilder(args).Build().Run();
            try
            {
                Log.Information("Starting host===========================================================");

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args).UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>{
                webBuilder.UseStartup<Startup>()
                 .UseUrls("http://*:6009");
            });
    }
}
