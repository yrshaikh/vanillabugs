using Data.Core.EntityFramework;

namespace Data.Core.Repositories.Issues
{
    public interface  IIssueRepository
    {
        void Create(Issue issue, out int issueId);
    }
}