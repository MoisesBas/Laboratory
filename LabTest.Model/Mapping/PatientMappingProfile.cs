using LabTest.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Mapping
{
   public class PatientMappingProfile:AutoMapper.Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<PatientReadModel, Domain.Core.Patient>();
            CreateMap<Domain.Core.Patient, PatientReadModel>();
            CreateMap<PatientCreateModel, Domain.Core.Patient>();
            CreateMap<PatientUpdateModel, Domain.Core.Patient>();
        }
    }
}
