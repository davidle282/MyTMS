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

        //dotnet ef migrations add CreateOrgVehicleTable --project C:\Users\DavidLe\Documents\Research\MyTMS\MyTMS.Data
        //dotnet ef database update --project C:\Users\DavidLe\Documents\Research\MyTMS\MyTMS.Data
    }

}
