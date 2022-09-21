using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ValueObject
    {
        public void ThrowDomainException(string message)
        {
            throw new Exception(message);
        }
    }
}
