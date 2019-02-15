using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Core
{
   public class PathologyTestModel:BaseModel<Guid>
    {
        public string Name { get; set; }

        public TestTypeModel TestType { get; set; }

        public Guid TestTypeId { get; set; }
    }
}
