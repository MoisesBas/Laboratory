using LabTest.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Mapping
{
  public  class ReportMappingProfile:AutoMapper.Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<ReportModel, Domain.Core.Report>();
            CreateMap<Domain.Core.Report, ReportModel>();
        }
    }
}
