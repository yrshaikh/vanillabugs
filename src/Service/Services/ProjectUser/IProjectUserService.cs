using System;
using System.Collections.Generic;

namespace Service.Core
{
    public interface IProjectUserService
    {
        void AddUsersToProject(int projectId, List<Guid> users);
        List<object> GetProjectUsersByProjectId(int projectId);
    }
}