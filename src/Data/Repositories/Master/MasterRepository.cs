using System.Collections.Generic;
using System.Linq;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public class MasterRepository : IMasterRepository
    {
        public List<IssueStatusMaster> GetIssueStatusList()
        {
            using (ProjectManagementEntities entities = new ProjectManagementEntities())
            {
                return entities.IssueStatusMasters.ToList();
            }
        }

        public List<IssuePriorityMaster> GetIssuePriorityList()
        {
            using (ProjectManagementEntities entities = new ProjectManagementEntities())
            {
                return entities.IssuePriorityMasters.ToList();
            }
        }

        public List<IssueTypeMaster> GetIssueTypeList()
        {
            using (ProjectManagementEntities entities = new ProjectManagementEntities())
            {
                return entities.IssueTypeMasters.ToList();
            }
        }
    }
}
