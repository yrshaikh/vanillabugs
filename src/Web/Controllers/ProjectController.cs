using System.Collections.Generic;
using System.Web.Mvc;
using Service.Core;

namespace Web.Controllers
{
    [Authorize]
    public class ProjectUserController : Controller
    {
        private readonly IProjectUserService _projectUserService;
        public ProjectUserController(IProjectUserService projectUserService)
        {
            _projectUserService = projectUserService;
        }

        // GET projectusers/get/id
        public JsonResult Get(int id)
        {
            List<object> projectUsers = _projectUserService.GetProjectUsersByProjectId(id);
            return Json(projectUsers, JsonRequestBehavior.AllowGet);
        }
    }
}