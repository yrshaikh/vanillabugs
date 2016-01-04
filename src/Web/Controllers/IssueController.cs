using System.Web.Mvc;
using Service.Core;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
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
                model.ReportedBy = WebHelper.GetLoggedInUserId().ToString();

                _issueService.CreateNewIssue(model, out issueId);
                createdSuccessfully = true;
                isModelValid = true;
            }

            return Json(new { createdSuccessfully, issueId, isModelValid }, JsonRequestBehavior.AllowGet);
        }
    }
}