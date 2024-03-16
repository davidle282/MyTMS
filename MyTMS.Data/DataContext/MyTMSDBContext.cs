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

    }

}
