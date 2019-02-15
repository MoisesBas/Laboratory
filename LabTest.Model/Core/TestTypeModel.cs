using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Core
{
   public class TestTypeModel:BaseModel<Guid>
    {
        public string Name { get; set; }

        public IEnumerable<PathologyTestModel> Tests { get; set; }
    }
}
