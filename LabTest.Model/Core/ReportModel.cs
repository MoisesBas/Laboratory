using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Core
{
    public class ReportModel:BaseModel<Guid>

    {
        public PathologyTestModel Test { get; set; }

        public Guid PatientId { get; set; }

        public string Comment { get; set; }
    }
}
