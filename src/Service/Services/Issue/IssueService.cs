using Data.Core.EntityFramework;
using Data.Core.Repositories.Issues;

namespace Service.Core
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public void CreateNewIssue(CreateIssueModel model, out int issueId)
        {
            Issue newIssue = CustomMapper.Map<CreateIssueModel, Issue>(model);
            _issueRepository.Create(newIssue, out issueId);
        }
    }
}
