using System.Web.Mvc;

namespace Web.Controllers
{
    public class TemplateController : Controller
    {
        public ActionResult Projects()
        {
            return View("Projects");
        }

        public ActionResult Issues()
        {
            return View("Issues");
        }
    }
}