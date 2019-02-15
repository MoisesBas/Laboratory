using System;
using System.Collections.Generic;
using System.Text;
using static LabTest.Domain.Core.Enums;

namespace LabTest.Domain.Core
{
    public class Patient : BaseEntity<Guid>
    {
        public Patient()
        {
            Reports = new HashSet<Report>();
            PathologyTests = new HashSet<PathologyTest>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ParentName { get; set; }

        public string SpouseName { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public virtual ICollection<Report> Reports { get; private set; }

        public virtual ICollection<PathologyTest> PathologyTests { get; private set; }
    }
}
