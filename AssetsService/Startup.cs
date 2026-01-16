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
using AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.RFId;
using AssetsService.Application.Handlers.Assets.QueryHandlers.Assets;
using AssetsService.Api.Service;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AssetsService.Infrastructure.Helpers;
using Microsoft.Identity;
using Microsoft.Identity.Web;

namespace AssetsService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            Dictionary<string, string> myConfiguration = new Dictionary<string, string>
                {
                    {"AzureAd:Instance",Environment.GetEnvironmentVariable("AZUREAD_INSTANCE")},
                    {"AzureAd:Domain",Environment.GetEnvironmentVariable("AZUREAD_DOMAIN")},
                    {"AzureAd:clientId", Environment.GetEnvironmentVariable("AZUREAD_CID")},
                    {"AzureAd:TenantId", Environment.GetEnvironmentVariable("AZUREAD_TID")},
                    {"AzureAd:audience",Environment.GetEnvironmentVariable("AZUREAD_AUD")},
                };
            IConfiguration configurationENV = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
           
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_USER_PASSWORD");
            var dbUserName = Environment.GetEnvironmentVariable("DB_LOGIN_USERNAME");
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID={dbUserName};Password={dbPassword}";
            if(dbHost==null)
            {
                connectionString = Configuration.GetConnectionString("AssetsDB");
                configurationENV = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
                services.AddControllers();
            }
            else
            {
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(configurationENV.GetSection("AzureAd"));
                services.AddControllers();
            }
            services.AddDbContext<AssetsService.Infrastructure.DBContext.DBContextCore>(
            m => m.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assets.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "www.Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICableRepository, CableRepository>();
            //services.AddMediatR(typeof(CreateCableHandler).GetTypeInfo().Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCableHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateCableHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePadHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdatePadHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IsActivePadHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateRFIdHandler).GetTypeInfo().Assembly));
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateRFIdHandler).GetTypeInfo().Assembly));
            services.AddTransient<ICableRepository, CableRepository>();
            services.AddScoped<IPadRepository, PadRepository>();
            services.AddScoped<IRFIdRepository, RFIdRepository>();

            services.AddTransient<ITotalLocationAndChargerRepository, TotalLocationAndChargerRepository>();


            services.AddTransient<IDispenserRepository, DispenserRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateDispenserHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateDispenserHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteDispenserHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IsActiveDispenserHandler).GetTypeInfo().Assembly));

            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateLocationHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateLocationHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteLocationHandler).GetTypeInfo().Assembly));
           

            services.AddTransient<IPowerCabinetRepository, PowerCabinetRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePowerCabinetHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdatePowerCabinetHandler).GetTypeInfo().Assembly));

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateVehicleHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateVehicleHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IsActiveVehicleHandler).GetTypeInfo().Assembly));

            services.AddTransient<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateVehicleMakeHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateVehicleMakeHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteVehicleMakeMakeHandler).GetTypeInfo().Assembly));

            services.AddTransient<IMakeMasterRepository, MakeMasterRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateMakeMasterHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateMakeMasterHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteMakeMasterHandler).GetTypeInfo().Assembly));

            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateModelHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateModelHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteModelHandler).GetTypeInfo().Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateModemHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateModemHandler).GetTypeInfo().Assembly));
            services.AddTransient<IModemRepository, ModemRepository>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePosHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdatePosHandler).GetTypeInfo().Assembly));
            services.AddTransient<IPosRepository, PosRepository>();

            services.AddTransient<ICombineAssetRepository, CombineAssetRepository>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ExternalHandler).GetTypeInfo().Assembly));
            services.AddTransient<IExternalRepository, ExternalRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ITimeZoneRepository, TimeZoneRepository>();
            services.AddTransient<IDispenserLocationRepository, DispenserByLocationIdRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateSwitchGearHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateSwitchGearHandler).GetTypeInfo().Assembly));
            services.AddTransient<ISwitchGearRepository, SwitchGearRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IsActiveAssetHandler).GetTypeInfo().Assembly));
            services.AddScoped<TokenBase>();
            services.AddHealthChecks()
                .AddCheck<AssetHealthCheck>("example_health_check");



        }
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResultStatusCodes =
                    {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                    }
                });
            });
        }
    }
}



 
