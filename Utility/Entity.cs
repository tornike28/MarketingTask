using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public void ThrowDomainException(string message)
        {
            throw new Exception(message);
        }
    }
}
