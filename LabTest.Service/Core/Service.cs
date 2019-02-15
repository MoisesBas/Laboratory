using AutoMapper;
using LabTest.Domain.Core;
using LabTest.Model.Core;
using LabTest.Repository;
using LabTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabTest.Service.Core
{
    public class Service<TDomain, TReadModel, TCreateModel,TUpdateModel> : Service<TDomain, TReadModel, TCreateModel, TUpdateModel, Guid>
        where TDomain : BaseEntity
        where TReadModel : BaseModel
        where TCreateModel: class
        where TUpdateModel: BaseModel
    {       
        public Service(IRepository<TDomain, Guid> repository, IMapper mapper) : base(repository,mapper)
        {
        }
    }

    public class Service<TDomain, TReadModel, TCreateModel, TUpdateModel,TPrimaryKey> : IService<TDomain, TReadModel, TCreateModel, TUpdateModel,TPrimaryKey>
        where TDomain : BaseEntity<TPrimaryKey>
        where TReadModel : BaseModel<TPrimaryKey>
        where TCreateModel: class
        where TUpdateModel: BaseModel<TPrimaryKey>

        where TPrimaryKey : struct
    {
        private readonly IMapper _mapper;
        protected IRepository<TDomain, TPrimaryKey> Repository { get; private set; }

        public Service(IRepository<TDomain, TPrimaryKey> repository, IMapper mapper)
        {
            this.Repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TReadModel> CreateAsync(TCreateModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            TDomain entity = await this.Repository.CreateAsync(_mapper.Map<TDomain>(model),cancellationToken).ConfigureAwait(false);
            return _mapper.Map<TReadModel>(entity);
        }

        public virtual async Task<TReadModel> DeleteAsync(TUpdateModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            TDomain entity = await this.Repository.DeleteAsync(_mapper.Map<TDomain>(model),cancellationToken).ConfigureAwait(false);
            return _mapper.Map<TReadModel>(entity);
        }

        public virtual async Task<IEnumerable<TReadModel>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<TDomain> entities = await this.Repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<TReadModel>>(entities);
        }

        public virtual async Task<TReadModel> GetAsync(TPrimaryKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            TDomain entity = await this.Repository.GetAsync(id,cancellationToken).ConfigureAwait(false);
            return _mapper.Map<TReadModel>(entity);
        }

        public virtual async Task<TReadModel> UpdateAsync(TUpdateModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            TDomain entity = await this.Repository.UpdateAsync(Mapper.Map<TDomain>(model)).ConfigureAwait(false);
            return Mapper.Map<TReadModel>(entity);
        }
    }
}
