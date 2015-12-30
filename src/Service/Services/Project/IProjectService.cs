using System.Collections.Generic;

namespace Service.Core
{
    public interface IProjectService
    {
        ProjectModel GetProject(int id);
        List<ProjectListModel> GetProjectListing(string userId);
        void CreateNewProject(CreateProjectModel model, out int projectId);
    }
}