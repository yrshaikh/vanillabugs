using System.Collections.Generic;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public interface IMasterRepository
    {
        List<IssueStatusMaster> GetIssueStatusList();
        List<IssuePriorityMaster> GetIssuePriorityList();
        List<IssueTypeMaster> GetIssueTypeList();
    }
}