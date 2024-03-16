using MyTMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Repository
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);

        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity model);

        Task<bool> DeleteAsync(long id);

        Task<IEnumerable<TEntity>> GetManyByIds(IReadOnlyList<long> keys);
    }
}
