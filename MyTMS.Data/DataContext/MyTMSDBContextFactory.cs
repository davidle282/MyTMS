using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.DataContext
{
    public class MyTMSDBContextFactory: IMyTMSDBContextFactory
    {
        public virtual MyTMSDBContext Current { get; }

        private readonly IDbContextFactory<MyTMSDBContext> p_DbContextFactory;
        public MyTMSDBContextFactory(IDbContextFactory<MyTMSDBContext> dbContextFactory, MyTMSDBContext scopedDbContext)
        {
            p_DbContextFactory = dbContextFactory;
            Current = scopedDbContext;
        }

        public virtual MyTMSDBContext CreateDbContext()
        => p_DbContextFactory.CreateDbContext();

        public virtual Task<MyTMSDBContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
            => p_DbContextFactory.CreateDbContextAsync(cancellationToken);
    }
}
