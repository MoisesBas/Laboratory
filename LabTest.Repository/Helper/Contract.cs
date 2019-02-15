using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Repository.Helper
{
    public class Contract
    {
        public static void Requires<TException>(bool Predicate, string Message)
           where TException : Exception, new()
        {
            if (!Predicate)
            {
                throw new TException();
            }
        }
    }
}
