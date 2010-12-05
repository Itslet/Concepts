using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;


namespace Concepts.Core
{
    public class Person : Entity
    {
        public virtual string GivenName { get; set; }
        public virtual string SurName { get; set; }
        public virtual string SurNamePrefix { get; set; }
        public virtual string OfficialName { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }

        virtual public Iesi.Collections.Generic.ISet<PersonAddress> Addresses { get; set; }
        
        public Person() {
            Addresses = new HashedSet<PersonAddress>();
        }

        
        
        
        /*
        public virtual string BirthPlace { get; set; }
        public virtual string BirthCountry { get; set; }
        public virtual string Nationality { get; set; }
        public virtual string MemberType { get; set; }
        public virtual string Sex { get; set; }
        public virtual string Email { get; set; }
        public virtual string MobilePhone { get; set; }
        public virtual DateTime? DateOfChristening { get; set; }
        public virtual string OriginalReligion { get; set; }
        public virtual DateTime? DateOfBabyDeclaration { get; set; }
        public virtual DateTime? SubscribeDate { get; set; }
        public virtual DateTime? UnSubscribeDate { get; set; }
        public virtual string ReasonUnsubscription { get; set; }
        public virtual string PersonDescription { get; set; }
        public virtual string PersonPicture { get; set; }
        public virtual DateTime? PersonPictureDate { get; set; }
         */
        
   }
}