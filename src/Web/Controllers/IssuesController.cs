using System.Web.Mvc;
using Service.Core;

namespace Web.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly IIssueService _issueService;
        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpPost]
        public JsonResult Create(CreateIssueModel model)
        {
            bool createdSuccessfully = false;
            int issueId = -1;
            bool isModelValid = false;
            if (ModelState.IsValid)
            {
                _issueService.CreateNewIssue(model, out issueId);
                createdSuccessfully = true;
                isModelValid = true;
            }

            return Json(new { createdSuccessfully, issueId, isModelValid }, JsonRequestBehavior.AllowGet);
        }
    }
}