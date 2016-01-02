using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Service.Core;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: /project/get/
        public JsonResult Get()
        {
            List<ProjectListModel> projects = _projectService.GetProjectListing(User.Identity.GetUserId());
            projects.ForEach(x => x.UpdatedDateTimeMoment = DateTimeHelpers.GetPrettyDate(x.UpdatedDateTime));
            return Json(new { data = projects }, JsonRequestBehavior.AllowGet);
        }

        // GET: /project/get/id
        public JsonResult GetById(int id)
        {
            ProjectModel project = _projectService.GetProject(id);
            return Json(new { project }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        // POST: /project/create
        public JsonResult Create(CreateProjectModel model)
        {
            model.Users = new List<Guid> {WebHelper.GetLoggedInUserId()};

            bool createdSuccessfully = false;
            int projectId = -1;
            bool isModelValid = false;
            if (ModelState.IsValid)
            {
                _projectService.CreateNewProject(model, out projectId);
                createdSuccessfully = true;
                isModelValid = true;
            }

            return Json(new { createdSuccessfully, projectId, isModelValid }, JsonRequestBehavior.AllowGet);
        }
    }
}