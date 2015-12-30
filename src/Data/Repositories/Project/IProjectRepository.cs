using System.Collections.Generic;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public interface IProjectRepository
    {
        void CreateNewProject(Project project, out int projectId);
        List<Project> GetProjectForUser(string userId);
        List<Project> GetProjects(Specification<Project> specification);
    }
}