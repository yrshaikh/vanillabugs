using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public class ProjectRepository : IProjectRepository
    {
        public void CreateNewProject(Project project, out int projectId)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                dbContext.Projects.Add(project);
                dbContext.SaveChanges();
                projectId = project.Id;
            }
        }

        public List<Project> GetProjectForUser(string userId)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                return dbContext.UserProjectMappings.Where(x => x.UserId == userId).Select(x => x.Project).Include(x => x.UserProjectMappings).ToList();
            }
        }

        public List<Project> GetProjects(Specification<Project> specification)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                return specification.SatisfyingEntitiesFrom(dbContext.Projects).ToList();
            }
        }
    }
}
