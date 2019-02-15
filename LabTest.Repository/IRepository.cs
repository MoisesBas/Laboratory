using LabTest.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabTest.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : BaseEntity
    {
    }

    public interface IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        Task<TEntity> GetAsync(TPrimaryKey id, CancellationToken cancellationToken = default(CancellationToken));

        Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<IQueryable<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] propertySelectors);
    }
}
