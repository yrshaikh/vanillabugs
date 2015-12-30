using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Service.Core;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public JsonResult Get()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<ApplicationUser> allUsers = context.Users.ToList();
            List<AspNetUserModel> aspNetUsers = allUsers.Select(x => new AspNetUserModel
            {
                Id = x.Id,
                Email = x.Email,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            return Json(new { users = aspNetUsers }, JsonRequestBehavior.AllowGet);
        }
    }
}