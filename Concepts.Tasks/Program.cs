using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Concepts.Core;

namespace Concepts.Tasks
{
    class Program
    {

        public static void createDatabase()
        {
            var nhconfig = new Configuration().Configure();
            var sessionFactory = nhconfig.BuildSessionFactory();
            var schemaExport = new SchemaExport(nhconfig);
            schemaExport.SetOutputFile(@"concepts.sql")
                .Execute(true, true, false);
            Console.WriteLine("I created your database");
        }

        public static void StuffIt()
        {
            var nhconfig = new Configuration().Configure();
            var sessionFactory = nhconfig.BuildSessionFactory();
            
            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    Person p = new Person();
                    p.GivenName = "James";
                    p.SurName = "The Butler";

                    Address a = new Address();
                    a.StreetName = "WhateverStreet";
                    a.StreetNumber = "119";
                    a.City = "Anchorage";

                    PersonAddress pa = new PersonAddress();
                    pa.Person = p;
                    pa.Address = a;

                    session.SaveOrUpdate(p);
                    session.SaveOrUpdate(a);
                    session.SaveOrUpdate(pa);
                    tx.Commit();
                }
            }
            Console.WriteLine("Finished dude");
            

        }


        public void QueryMeWho()
        {
            var nhconfig = new Configuration().Configure();
            var sessionFactory = nhconfig.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    IQuery query = session.CreateQuery("from Person");
                    IEnumerable<Person> persons2 = query.Enumerable<Person>();

                    IList<Person> persons = query.List<Person>();
                    persons2.ToList().ForEach(p => Console.WriteLine("Blah " + p.GivenName));

                    foreach (Person cat in query.Enumerable())
                    {
                        Console.Out.WriteLine("Deze persoon " + cat.GivenName);
                        foreach (PersonAddress pa in cat.Addresses)
                        {
                            Console.WriteLine("woont hier: {0}", pa.Address.StreetName.ToString());
                        }
                    }
                    tx.Commit();
                }
            }
            Console.WriteLine("Finished dude");
            Console.ReadKey();
           
        }


        static void Main(string[] args)
        {
            //createDatabase();
            StuffIt();
        }
    }
}
