using System;
using System.Collections.Generic;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public interface IProjectUserRepository
    {
        void AddUsersToProject(int projectId, List<Guid> users);
        List<GetUsersInProjectResult> GetProjectUsersByProjectId(int projectId);
    }
}