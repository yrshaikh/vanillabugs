using System.Collections.Generic;

namespace Service.Core
{
    public interface IMasterService
    {
        List<IssueMasterModel> GetIssueStatusList();
        List<IssueMasterModel> GetIssuePriorityList();
        List<IssueMasterModel> GetIssueTypeList();
    }
}