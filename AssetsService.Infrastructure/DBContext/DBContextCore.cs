using AssetsService.Core.Entities;
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
         //   optionsBuilder.UseSqlServer(@"Data Source=LT1828; Initial Catalog =Assets_5_aug; User ID =sa; Password=Ocpp@12345");
         //}

        

        public DbSet<AssetsService.Core.Entities.Cable> Cables { get; set; }
        public DbSet<AssetsService.Core.Entities.Status> Status { get; set; }

        public DbSet<AssetsService.Core.Entities.MakeMaster> MakeMaster { get; set; }

        public DbSet<AssetsService.Core.Entities.Vehicle> Vehicle { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleModelYear> VehicleModelYear { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleModel> VehicleModel { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleMake> VehicleMake { get; set; }
        public DbSet<AssetsService.Core.Entities.VehicleRFID> VehicleRFID { get; set; }
        public DbSet<AssetsService.Core.Entities.SubscriptionsGroupDetails> SubscriptionsGroupDetails { get; set; }
        public DbSet<AssetsService.Core.Entities.Level> Level { get; set; }
        public DbSet<AssetsService.Core.Entities.Protocol> Protocol { get; set; }
        public DbSet<AssetsService.Core.Entities.ChargerType> ChargerType { get; set; }
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

        public DbSet<AssetsService.Core.Entities.Charger> Charger { get; set; }


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

        public DbSet<AssetsService.Core.Entities.Country> Country {get;set;}
        public DbSet<AssetsService.Core.Entities.State> State {get;set;}
        public DbSet<AssetsService.Core.Entities.City> City {get;set;}
        public DbSet<AssetsService.Core.Entities.SwitchGear> SwitchGears { get; set; }
        public DbSet<AssetsService.Core.Entities.Users> Users { get; set; }
        public DbSet<AssetsService.Core.Entities.Customers> Customers { get; set; }
        public DbSet<AssetsService.Core.Entities.ChargerStatus> ChargerStatuses { get; set; }
        public virtual DbSet<ChargerStatusHistory> ChargerStatusHistories { get; set; }
        public DbSet<AssetsService.Core.Entities.PricePlanLocationsMapper> PricePlanLocationsMapper { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChargerStatus>(entity =>
            {
                entity.ToTable("ChargerStatus");

                entity.Property(e => e.ChargerStatus1)
                    .HasMaxLength(255)
                    .HasColumnName("ChargerStatus");

                entity.Property(e => e.ConnectorStatus).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IdTag).HasMaxLength(20);

                entity.Property(e => e.ModifiedoN).HasColumnType("datetime");

                entity.Property(e => e.ReservationExpiryDate).HasColumnType("datetime");
                entity.HasOne(d => d.Charger)
                    .WithMany(p => p.ChargerStatuses)
                    .HasForeignKey(d => d.ChargerId);
            });
            builder.Entity<ChargerStatusHistory>(entity =>
            {
                entity.ToTable("ChargerStatusHistory");

                entity.Property(e => e.ChargerStatus)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConnectorStatus).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.HasOne(d => d.Charger)
                    .WithMany(p => p.ChargerStatusHistories)
                    .HasForeignKey(d => d.ChargerId);
            });

            builder.Entity<AssetsService.Core.Entities.Cable>()
                .HasIndex(u => u.AssetId)
                .IsUnique();

            builder.Entity<AssetsService.Core.Entities.Model>()
               .HasIndex(u => u.ModelName)
               .IsUnique();

            builder.Entity<AssetsService.Core.Entities.RFIDReader>()
               .HasIndex(u => u.AssetId)
               .IsUnique();

            builder.Entity<AssetsService.Core.Entities.Pad>()
               .HasIndex(u => u.AssetId)
               .IsUnique();

            builder.Entity<AssetsService.Core.Entities.PowerCabinet>()
               .HasIndex(u => u.AssetId)
               .IsUnique();

            builder.Entity<AssetsService.Core.Entities.Charger>()
              .HasIndex(u => u.AssetId)
              .IsUnique();

            builder.Entity<AssetsService.Core.Entities.VehicleRFID>()
              .HasIndex(u => u.Name)
              .IsUnique();

            builder.Entity<AssetsService.Core.Entities.Modem>()
             .HasIndex(u => u.AssetId)
             .IsUnique();
        }
    }
}
