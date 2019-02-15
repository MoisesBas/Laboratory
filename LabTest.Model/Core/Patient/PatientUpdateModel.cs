using System;
using System.Collections.Generic;
using System.Text;
using static LabTest.Domain.Core.Enums;

namespace LabTest.Model.Core
{
   public class PatientUpdateModel: BaseModel<Guid>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ParentName { get; set; }

        public string SpouseName { get; set; }

        public BloodGroup BloodGroup { get; set; }
    }
}
