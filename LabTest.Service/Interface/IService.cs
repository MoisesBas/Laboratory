using LabTest.Domain.Core;
using LabTest.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabTest.Service.Interface
{
    public interface IService<TDomain, TReadModel,TCreateModel,TUpdateModel> : IService<TDomain, TReadModel, TCreateModel, TUpdateModel, Guid>
        where TDomain : BaseEntity
        where TReadModel : BaseModel
        where TCreateModel:class
        where TUpdateModel: BaseModel

    {
    }

    public interface IService<TDomain, TReadModel, TCreateModel, TUpdateModel,TPrimaryKey>
        where TDomain : BaseEntity<TPrimaryKey>
        where TReadModel : BaseModel<TPrimaryKey>
        where TCreateModel: class
        where TUpdateModel: BaseModel<TPrimaryKey>
        where TPrimaryKey : struct
    {
        Task<TReadModel> GetAsync(TPrimaryKey id, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<TReadModel>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<TReadModel> CreateAsync(TCreateModel model, CancellationToken cancellationToken = default(CancellationToken));

        Task<TReadModel> UpdateAsync(TUpdateModel model, CancellationToken cancellationToken = default(CancellationToken));

        Task<TReadModel> DeleteAsync(TUpdateModel model, CancellationToken cancellationToken = default(CancellationToken));
    }
}
