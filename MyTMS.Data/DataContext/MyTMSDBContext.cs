using Microsoft.EntityFrameworkCore;
using MyTMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.DataContext
{
    public class MyTMSDBContext : DbContext
    {
        public MyTMSDBContext(DbContextOptions<MyTMSDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
            
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        //dotnet ef migrations add CreateOrgVehicleTable --project C:\Users\DavidLe\Documents\Research\MyTMS\MyTMS.Data
        //dotnet ef database update --project C:\Users\DavidLe\Documents\Research\MyTMS\MyTMS.Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Cubic).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.CubicActual).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.WeightActual).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.CartageCharge).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.SurchargeCharge).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TotalCharge).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CurrentVehicle)
                    .WithMany(p => p.CurrentVehicleBookings)
                    .HasForeignKey(d => d.CurrentVehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Vehicle_CurrentVehicle");

                entity.HasOne(d => d.LastVehicle)
                    .WithMany(p => p.LastVehicleBookings)
                    .HasForeignKey(d => d.LastVehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Vehicle_LastVehicle");

                entity.HasOne(d => d.FreightPayer)
                    .WithMany(p => p.FreightPayerBookings)
                    .HasForeignKey(d => d.FreightPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Organization_FreightPayer");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.FreightCarrierBookings)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Organization_Carrier");
            });
        }


    }

}
