using Serilog;
using Serilog.Events;

namespace AssetsService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStringLogs");
            //string connectionString = "DefaultEndpointsProtocol=https;AccountName=assetswork;AccountKey=Rk7iyAEtGHdMWfojFlyE23dXYsMDUkH1zvLghSjWW9kZX7Ecv6wuJuvRifNQfOChKmY5d1Hvx7mE+AStxFztQw==;EndpointSuffix=core.windows.net";
            var containerName = Environment.GetEnvironmentVariable("ContainerName");
            //var containerName = "assets-service-log";
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console().WriteTo.Debug(outputTemplate: DateTime.Now.ToString()).WriteTo.File("./logs/log-.txt", rollingInterval: RollingInterval.Day)
                 .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
                 .WriteTo.AzureBlobStorage(connectionString, LogEventLevel.Information,
                        containerName,
                        "{yyyy}{MM}{dd}.txt",
                        null,
                        false,
                        TimeSpan.FromMinutes(1),
                        null,
                        true)
                 .CreateLogger();
            try
            {
                Log.Information("Starting AssetAPI-Service !");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpected !");
            }
            finally
            {
                Log.CloseAndFlush();
            }

          // Log.Logger = new LoggerConfiguration()
          //.MinimumLevel.Debug()
          //.MinimumLevel.Override("Microsoft", LogEventLevel.Error)
          //.Enrich.FromLogContext()
          //.WriteTo.File("Log//log.txt", rollingInterval: RollingInterval.Day)
          ////.WriteTo.Seq("http://localhost:5341")
          //.CreateLogger();

           
          //  try
          //  {
          //      Log.Information("Starting host===========================================================");

          //      return 0;
          //  }
          //  catch (Exception ex)
          //  {
               
          //      Log.Fatal(ex, "Host terminated unexpectedly");
          //      return 1;
          //  }
          //  finally
          //  {
          //      Log.CloseAndFlush();
          //  }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args).UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>{
                webBuilder.UseStartup<Startup>()
               .UseUrls("http://*:6009");
            });
    }
}
