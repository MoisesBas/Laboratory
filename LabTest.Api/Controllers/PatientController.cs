using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LabTest.Domain.Core;
using LabTest.Model.Core;
using LabTest.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabTest.Api.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IService<Patient, PatientReadModel, PatientCreateModel, PatientUpdateModel, Guid> _service;
        public PatientController(IService<Patient, PatientReadModel, PatientCreateModel, PatientUpdateModel, Guid> service) 
        {
            _service = service;
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(Patient), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           PatientCreateModel model)
        {
            var readModel = await _service.CreateAsync(model, cancellationToken).ConfigureAwait(false);
            return Ok(readModel);
        }
    }
}