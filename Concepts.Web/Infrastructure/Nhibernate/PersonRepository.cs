using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Concepts.Core;

namespace Concepts.Web
{
    public class PersonRepository :IPersonRepository
    {
        private ISession _session;
        public PersonRepository(ISession session)
        {
            _session = session;
        }
        public IQueryable<Person> GetPersons()
        {
            return _session.CreateCriteria<Person>().List<Person>().AsQueryable();
        }
    }
}