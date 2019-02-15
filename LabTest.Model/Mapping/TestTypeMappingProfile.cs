using LabTest.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Mapping
{
    public class TestTypeMappingProfile:AutoMapper.Profile
    {
        public TestTypeMappingProfile()
        {
            CreateMap<TestTypeModel, Domain.Core.TestType>();
            CreateMap<Domain.Core.TestType, TestTypeModel>();
        }
    }
}
