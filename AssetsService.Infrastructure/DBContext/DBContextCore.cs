using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace AssetsService.Infrastructure.DBContext
{

    public class DBContextCore : DbContext
    {
        public DBContextCore(DbContextOptions<DBContextCore> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   // optionsBuilder.UseSqlServer(@"Data Source= LT01814; Initial Catalog =asset_db4; User ID =sa; Password=Ocpp@1234;");
        //}




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LT1828; Initial Catalog =asset_18-july-Location-update; User ID =sa; Password=Ocpp@12345");
        //}

        public DbSet<AssetsService.Core.Entities.Cable> Cables { get; set; }
        public DbSet<AssetsService.Core.Entities.Status> Status { get; set; }

        public DbSet<AssetsService.Core.Entities.MakeMaster> MakeMaster { get; set; }

        public DbSet<AssetsService.Core.Entities.Vehicle> Vehicle { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleModelYear> VehicleModelYear { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleModel> VehicleModel { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleMake> VehicleMake { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleRFID> VehicleRFID { get; set; }

        public DbSet<AssetsService.Core.Entities.Level> Level { get; set; }
        public DbSet<AssetsService.Core.Entities.Protocol> Protocol { get; set; }
        public DbSet<AssetsService.Core.Entities.PlugType> PlugType { get; set; }
        public DbSet<AssetsService.Core.Entities.Port> Port { get; set; }
        public DbSet<AssetsService.Core.Entities.Connector> Connector { get; set; }

        public DbSet<AssetsService.Core.Entities.Model> Model { get; set; }

        public DbSet<AssetsService.Core.Entities.Modem> Modem { get; set; }

        public DbSet<AssetsService.Core.Entities.Pos> Pos { get; set; }

        public DbSet<AssetsService.Core.Entities.Currency> Currency { get; set; }

        public DbSet<AssetsService.Core.Entities.PricePlan> PricePlan { get; set; }


        public DbSet<AssetsService.Core.Entities.ModemType> ModemType { get; set; }

        public DbSet<AssetsService.Core.Entities.Location> Locations { get; set; }


        public DbSet<AssetsService.Core.Entities.PriceType> PriceType { get; set; }

        public DbSet<AssetsService.Core.Entities.Unit> Unit { get; set; }

        public DbSet<AssetsService.Core.Entities.Dispenser> Dispenser { get; set; }

        public DbSet<AssetsService.Core.Entities.DispenserStatus> DispenserStatus { get; set; }


        public DbSet<AssetsService.Core.Entities.PowerCabinet> PowerCabinet { get; set; }


        public DbSet<AssetsService.Core.Entities.LocationAddress> LocationAddress { get; set; }

        public DbSet<AssetsService.Core.Entities.LocationSchedule> LocationSchedule { get; set; }

        public DbSet<AssetsService.Core.Entities.LocationStatus> LocationStatus { get; set; }


        public DbSet<AssetsService.Core.Entities.Pad> Pads { get; set; }
        public DbSet<AssetsService.Core.Entities.SubscriptionsGroup> SubscriptionsGroup { get; set; }
        public DbSet<AssetsService.Core.Entities.SubscriptionPlan> SubscriptionPlan { get; set; }
        public DbSet<AssetsService.Core.Entities.RFIDReader> RFIDReaders { get; set; }
        public DbSet<AssetsService.Core.Entities.Vendor> Vendor { get; set; }

        public DbSet<AssetsService.Core.Entities.Department> Department {get;set;}

        public DbSet<AssetsService.Core.Entities.OperatorUserMapper> OperatorUserMapper {get;set;}



    }

}

