using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Domain.Core
{
    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }

    public abstract class BaseEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
