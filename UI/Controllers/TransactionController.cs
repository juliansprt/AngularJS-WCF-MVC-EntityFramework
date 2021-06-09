using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Productos
        public ActionResult Create()
        {
            return PartialView();
        }
    }
}