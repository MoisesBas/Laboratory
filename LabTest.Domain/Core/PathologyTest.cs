using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Domain.Core
{
    public class PathologyTest : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public TestType Type { get; set; }

        public Guid TestTypeId { get; set; }

        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
