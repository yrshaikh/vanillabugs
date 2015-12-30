using System;
using System.Collections.Generic;

namespace Data.Core
{
    public interface IProjectUserRepository
    {
        void AddUsersToProject(int projectId, List<Guid> users);
    }
}