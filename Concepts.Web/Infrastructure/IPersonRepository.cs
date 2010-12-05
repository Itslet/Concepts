using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Concepts.Core;

namespace Concepts.Web
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetPersons();
    }
}