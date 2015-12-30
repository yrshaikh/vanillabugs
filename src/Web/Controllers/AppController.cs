using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Core.Controllers
{
    [Authorize]
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            return View();
        }
    }
}
