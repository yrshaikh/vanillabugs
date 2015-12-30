using Data.Core.EntityFramework;

namespace Data.Core.Repositories.Issues
{
    public class IssueRepository : IIssueRepository 
    {
        public void Create(Issue issue, out int issueId)
        {
            using (ProjectManagementEntities entities = new ProjectManagementEntities())
            {
                entities.Issues.Add(issue);
                entities.SaveChanges();
                issueId = issue.Id;
            }
        }
    }
}
