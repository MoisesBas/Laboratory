using LabTest.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabTest.Repository
{
    public class Repository<TDomain, TPrimaryKey> : IRepository<TDomain, TPrimaryKey>
       where TDomain : BaseEntity<TPrimaryKey>
       where TPrimaryKey : struct
    {
        private Func<Task<EntityEntry<TDomain>>, bool, Task<TDomain>> _executor;

        protected LabTestDbContext Context { get; private set; }

        public Repository(LabTestDbContext context)
        {
            this.Context = context;
            this._executor = async (Task<EntityEntry<TDomain>> action, bool isSaveTransaction) =>
            {
                try
                {
                    TDomain execEntity = (await action.ConfigureAwait(false))?.Entity;

                    if (isSaveTransaction && execEntity != null)
                    {
                        await this.Context.SaveChangesAsync().ConfigureAwait(false);
                    }

                    return execEntity;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            };
        }

        public virtual async Task<TDomain> CreateAsync(TDomain entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._executor(this.Context.AddAsync<TDomain>(entity,cancellationToken), true).ConfigureAwait(false);
        }

        public virtual async Task<TDomain> DeleteAsync(TDomain entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._executor(Task.FromResult(this.Context.Remove<TDomain>(entity)), true).ConfigureAwait(false);
        }

        public virtual async Task<IQueryable<TDomain>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.FromResult(this.Context.Set<TDomain>()).ConfigureAwait(false);
        }

        public virtual async Task<TDomain> GetAsync(TPrimaryKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Context.FindAsync<TDomain>(id,cancellationToken).ConfigureAwait(false);
        }

        //public virtual async Task<TDomain> UpdateAsync(TDomain entity)
        //{
        //    this.Context.Set<TDomain>.Include(patient => patient.Reports);
        //    return await this._executor(Task.FromResult(this.Context.Update<TDomain>(entity)), true).ConfigureAwait(false);
        //}

        public virtual async Task<IQueryable<TDomain>> GetAllIncludingAsync(params Expression<Func<TDomain, object>>[] propertySelectors)
        {
            IQueryable<TDomain> query = this.Context.Set<TDomain>().AsQueryable();
            propertySelectors?.ToList()?.ForEach(s => query = query.Include(s));
            return await Task.FromResult(query).ConfigureAwait(false);
        }
    }
}
