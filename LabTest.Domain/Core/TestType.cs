using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Domain.Core
{
    public class TestType : BaseEntity<Guid>
    {
        public TestType()
        {
            Tests = new HashSet<PathologyTest>();
        }

        public string Name { get; set; }

        public virtual ICollection <PathologyTest> Tests { get; set; }
    }
}
