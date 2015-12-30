namespace Service.Core
{
    public interface IIssueService
    {
        void CreateNewIssue(CreateIssueModel model, out int issueId);
    }
}