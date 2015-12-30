using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Core;

namespace Web.Core.Controllers
{
    public class MasterController : Controller
    {
        private readonly IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        public JsonResult IssueStatuses()
        {
            List<IssueMasterModel> data = _masterService.GetIssueStatusList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IssuePriorities()
        {
            List<IssueMasterModel> data = _masterService.GetIssuePriorityList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IssueTypes()
        {
            List<IssueMasterModel> data = _masterService.GetIssueTypeList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}