using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.DataContext
{
    public interface IMyTMSDBContextFactory
    {
        public abstract MyTMSDBContext Current { get; }

        public abstract MyTMSDBContext CreateDbContext();

        public abstract Task<MyTMSDBContext> CreateDbContextAsync(CancellationToken cancellationToken = default);
    }
}
