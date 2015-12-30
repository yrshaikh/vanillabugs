using System;
using System.Collections.Generic;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public class ProjectUserRepository : IProjectUserRepository
    {
        public void AddUsersToProject(int projectId, List<Guid> users)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                foreach (var user in users)
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
    }
}
