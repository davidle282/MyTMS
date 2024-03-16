using Microsoft.EntityFrameworkCore;
using MyTMS.Data.DataContext;
using MyTMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContextFactory<MyTMSDBContext> _contextFactory;

        public Repository(IDbContextFactory<MyTMSDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {

                entity.CreatedOn = DateTimeOffset.Now;
                entity.UpdatedOn = DateTimeOffset.UtcNow;
                entity.Rowguid = Guid.NewGuid();
                await using var context = await _contextFactory.CreateDbContextAsync();
                context.Add(entity);
                await context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {

            await using var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
            context.Remove(entity);
            return await context.SaveChangesAsync() > 0;

        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            //await using var context = await _contextFactory.CreateDbContextAsync();
            return context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var result = await context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetManyByIds(IReadOnlyList<long> keys)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var result = await context.Set<TEntity>().Where(x => keys.Contains(x.Id)).ToListAsync();

            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {

            entity.UpdatedOn = DateTimeOffset.UtcNow;


            await using var context = await _contextFactory.CreateDbContextAsync();

            context.Update(entity);

            var result = await context.SaveChangesAsync();

            if (result == 0) return null;

            return entity;
        }

    }
}
