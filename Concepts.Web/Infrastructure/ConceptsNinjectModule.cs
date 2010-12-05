using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using NHibernate;

namespace Concepts.Web
{
    public class ConceptsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPersonRepository>().To<PersonRepository>();
            this.Bind<ISession>().ToMethod(x => MvcApplication.SessionFactory.GetCurrentSession());
        }
    }
}