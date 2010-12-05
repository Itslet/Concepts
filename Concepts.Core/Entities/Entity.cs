using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concepts.Core
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set;}
    }
}
