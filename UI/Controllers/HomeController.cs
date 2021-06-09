using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return PartialView();
        }

        // GET: Home
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}