using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepository _repo;
        public HomeController(IPersonRepository repository)
        {
            _repo = repository;
        }

        [TransactionFilter]
        public ActionResult Index()
        {
            var persons = this._repo.GetPersons();
            foreach (var p in persons)
            {
                Response.Write(p.GivenName + "<br />");
            }

            return View();
        }

    }


}
