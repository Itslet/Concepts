using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using System.Reflection;
using NHibernate;
using NHibernate.Context;
using NHibernate.Cfg;
using System.IO;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace Concepts.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Create the Nhibernate Sessionfactory
        /// </summary>
        public static ISessionFactory SessionFactory = CreateSessionFactory();
        public MvcApplication()
        {
            this.BeginRequest += new EventHandler(MvcApplication_BeginRequest);
            this.EndRequest += new EventHandler(MvcApplication_EndRequest);
        }

        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Bind(SessionFactory.OpenSession());
        }
        
        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));
            NHibernateProfiler.Initialize();
            return cfg.BuildSessionFactory();

        }

        /// <summary>
        /// Ordinary Global.asax stuff
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //important for Ninject to set this:
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        
        /// <summary>
        /// Ninject Kernel loads 
        /// </summary>
        /// <returns></returns>
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }

        /// <summary>
        /// Creates the controllerfactory (I think)
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
       
   
    }
}