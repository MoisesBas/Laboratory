using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Domain.Core
{
    public class Report : BaseEntity<Guid>
    {
        public PathologyTest Test { get; set; }

        public Patient Patient { get; set; }

        public Guid PatientId { get; set; }

        public string Comment { get; set; }
    }
}
