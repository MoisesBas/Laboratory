using LabTest.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Mapping
{
   public class PathologyTestMappingProfile:AutoMapper.Profile
    {
        public PathologyTestMappingProfile()
        {
            CreateMap<PathologyTestModel, Domain.Core.PathologyTest>();
            CreateMap<Domain.Core.PathologyTest, PathologyTestModel>();
        }
    }
}
