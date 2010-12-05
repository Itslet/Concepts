using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Web
{
    public class TransactionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = MvcApplication.SessionFactory.GetCurrentSession();
            session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = MvcApplication.SessionFactory.GetCurrentSession();

            using (session.Transaction)
            {
                if (filterContext.Exception == null)
                {
                    session.Transaction.Commit();
                }
                else
                {
                    session.Transaction.Rollback();
                }
            }
        }
    }
}