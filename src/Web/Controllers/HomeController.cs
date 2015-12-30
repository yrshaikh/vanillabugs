using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Service.Core;

namespace Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Home
        public ActionResult Index()
        {
            AppModel app = new AppModel
            {
                User = _userService.GetUser(User.Identity.GetUserId())
            };
            return View(app);
        }
    }
}