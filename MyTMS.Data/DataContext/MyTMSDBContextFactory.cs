using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace MyTMS.Data.DataContext
{
    public class MyTMSDBContextFactory: IDesignTimeDbContextFactory<MyTMSDBContext>
    {
        public MyTMSDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyTMSDBContext>();

            // Fallback connection string
            string connectionString = "Server=DESKTOP-3DB8J4Q\\SQLEXPRESS;Database=MyTMS;Integrated Security=True;User=davidsa;Password=Thien@123;TrustServerCertificate=True;Encrypt=True;";


            optionsBuilder.UseSqlServer(connectionString);

            return new MyTMSDBContext(optionsBuilder.Options);
        }
        //public virtual MyTMSDBContext Current { get; }

        //private readonly IDbContextFactory<MyTMSDBContext> p_DbContextFactory;
        //public MyTMSDBContextFactory(IDbContextFactory<MyTMSDBContext> dbContextFactory, MyTMSDBContext scopedDbContext)
        //{
        //    p_DbContextFactory = dbContextFactory;
        //    Current = scopedDbContext;
        //}

        //public virtual MyTMSDBContext CreateDbContext()
        //=> p_DbContextFactory.CreateDbContext();

        //public virtual Task<MyTMSDBContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
        //    => p_DbContextFactory.CreateDbContextAsync(cancellationToken);
    }
}
