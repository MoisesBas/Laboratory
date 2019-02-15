using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Model.Core
{
 
    public abstract class BaseModel : BaseModel<Guid>
    {
    }

    public abstract class BaseModel<TPrimaryKey> where TPrimaryKey : struct
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
