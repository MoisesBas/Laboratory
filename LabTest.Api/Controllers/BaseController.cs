using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabTest.Domain.Core;
using LabTest.Infrastructure;
using LabTest.Model.Core;
using LabTest.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabTest.Api.Controllers
{
   
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorModel), 422)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public class BaseController
        <TDomain, TReadModel, TCreateModel, TUpdateModel, TPrimaryKey> : ControllerBase
        where TDomain : BaseEntity<TPrimaryKey>
        where TReadModel : BaseModel<TPrimaryKey>
        where TCreateModel : class
        where TUpdateModel : BaseModel<TPrimaryKey>
        where TPrimaryKey : struct

    {
        public readonly IService<TDomain, TReadModel, TCreateModel, TUpdateModel, TPrimaryKey> _service;
        public BaseController(IService<TDomain, TReadModel, TCreateModel, TUpdateModel, TPrimaryKey> service)
        {
            _service = service;
        }
        protected virtual IActionResult ObjectResult(TReadModel readModel,
           int status)
        {
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = status
            });
        }
        protected virtual IActionResult ObjectResult(IEnumerable<TReadModel> readModel,
           int status)
        {
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = status
            });
        }
    }
}