using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concepts.Core
{
    public class PersonAddress : Entity
    {
        public virtual Person Person { get; set; }
        public virtual Address Address { get; set; }
        public virtual string Remark { get; set; }
        public virtual bool IsPostal { get; set; }
        public virtual DateTime? ValidFrom { get; set; }
        public virtual DateTime? ValidTo { get; set; }

    }
}
