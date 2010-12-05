using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace Concepts.Core
{
    public class Address : Entity
    {
        public virtual string StreetName { get; set; }
        public virtual string StreetNumber { get; set; }
        public virtual string PostcalCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string LandLine { get; set; }
        public virtual bool PostalAddress { get; set; }
        public virtual Iesi.Collections.Generic.ISet<PersonAddress> Persons { get; set; }
        
        public Address() {
            Persons = new HashedSet<PersonAddress>();
        }

        
    
    }
}
