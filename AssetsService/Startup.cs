using AssetsService.Application.Handlers.Assets.CommandHandlers;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Infrastructure.DBContext;
using AssetsService.Infrastructure.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AssetsService.Core.Repositories;
using AssetsService.Application.Handlers.Assets.CommandHandlers.Assets;
using AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.Pad;
using AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.SubscriptionPlan;
using AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.RFId;
using AssetsService.Application.Handlers.Assets.QueryHandlers.Assets;

namespace AssetsService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // public void ConfigureServices(IServiceCollection services)
        // {

        //     services.AddControllers();
        //     services.AddDbContext<AssetsService.Infrastructure.DBContext.DBContextCore>(
        //          m => m.UseSqlServer(Configuration.GetConnectionString("OcppDB")), ServiceLifetime.Singleton);
        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddControllers();
        //     services.AddDbContext<AssetsService.Infrastructure.DBContext.DBContextCore>(
        //          m => m.UseSqlServer(Configuration.GetConnectionString("OcppDB")), ServiceLifetime.Singleton);

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //     services.AddDbContextFactory<DBContextCore>(
            //options =>
            //    options.UseSqlServer(@"Data Source=LT1828; Initial Catalog =asset_18-july-Location-update; User ID =sa; Password=Ocpp@12345"));
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";
            services.AddDbContext<AssetsService.Infrastructure.DBContext.DBContextCore>(

            //m => m.UseSqlServer(Configuration.GetConnectionString("OcppDB")), ServiceLifetime.Transient);
            m => m.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assets.API", Version = "v1" });
            });
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICableRepository, CableRepository>();
            services.AddMediatR(typeof(CreateCableHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateCableHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreatePadHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePadHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateSubscriptionPlanHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateSubscriptionPlanHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateRFIdHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateRFIdHandler).GetTypeInfo().Assembly);
            ///services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICableRepository, CableRepository>();
            services.AddScoped<IPadRepository, PadRepository>();
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionRepository>();
            services.AddScoped<IRFIdRepository, RFIdRepository>();

            services.AddTransient<ITotalLocationAndChargerRepository, TotalLocationAndChargerRepository>();

            services.AddTransient<IDispenserRepository, DispenserRepository>();
            services.AddMediatR(typeof(CreateDispenserHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateDispenserHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteDispenserHandler).GetTypeInfo().Assembly);

            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddMediatR(typeof(CreateLocationHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateLocationHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteLocationHandler).GetTypeInfo().Assembly);
           

            services.AddTransient<IPowerCabinetRepository, PowerCabinetRepository>();
            services.AddMediatR(typeof(CreatePowerCabinetHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePowerCabinetHandler).GetTypeInfo().Assembly);

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddMediatR(typeof(CreateVehicleHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateVehicleHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteVehicleHandler).GetTypeInfo().Assembly);

            services.AddTransient<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddMediatR(typeof(CreateVehicleMakeHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateVehicleMakeHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteVehicleMakeMakeHandler).GetTypeInfo().Assembly);

            services.AddTransient<IMakeMasterRepository, MakeMasterRepository>();
            services.AddMediatR(typeof(CreateMakeMasterHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateMakeMasterHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteMakeMasterHandler).GetTypeInfo().Assembly);

            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddMediatR(typeof(CreateModelHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateModelHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteModelHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CreateModemHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateModemHandler).GetTypeInfo().Assembly);
            services.AddTransient<IModemRepository, ModemRepository>();

            services.AddMediatR(typeof(CreatePosHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePosHandler).GetTypeInfo().Assembly);
            services.AddTransient<IPosRepository, PosRepository>();

            services.AddMediatR(typeof(CreatePricePlanHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePricePlanHandler).GetTypeInfo().Assembly);
            services.AddTransient<IPricePlanRepository, PricePlanRepository>();

            
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assets.API v1"));
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assets.API v1"));
            }
            app.UseCors(buider =>
            
            
            {
                buider
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
