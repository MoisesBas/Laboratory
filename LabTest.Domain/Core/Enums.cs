using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Domain.Core
{
    public static class Enums
    {
        [Flags]
        public enum BloodGroup
        {
            A = 1,
            B = 2,
            O = 4,
            Negative = 8,
            Positive = 16
        }

        public enum Gender
        {
            None = 0,
            Female = 1,
            Male = 2,
            Other = 3
        }
    }
}
