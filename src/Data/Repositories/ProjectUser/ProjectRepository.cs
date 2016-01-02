using System;
using System.Collections.Generic;
using System.Linq;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public class ProjectUserRepository : IProjectUserRepository
    {
        public void AddUsersToProject(int projectId, List<Guid> users)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                foreach (Guid user in users)
                {
                    UserProjectMapping mapping = new UserProjectMapping
                    {
                        ProjectId = projectId,
                        UserId = user.ToString(),
                        CreatedDateTime = DateTime.Now
                    };
                    dbContext.UserProjectMappings.Add(mapping);    
                }
                dbContext.SaveChanges();
            }
        }

        public List<GetUsersInProjectResult> GetProjectUsersByProjectId(int projectId)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                return dbContext.get_users_in_project(projectId).ToList();
            }
        }
    }
}
