using System;
using System.Collections.Generic;
using Data.Core;

namespace Service.Core
{
    public class ProjectUserService : IProjectUserService
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IUserRepository _userRepository;
        public ProjectUserService(IProjectUserRepository projectUserRepository, IUserRepository userRepository)
        {
            _projectUserRepository = projectUserRepository;
            _userRepository = userRepository;
        }

        #region CREATE OR MODIFY
        public void AddUsersToProject(int projectId, List<Guid> users)
        {
            _projectUserRepository.AddUsersToProject(projectId, users);
        }
        #endregion
    }
}
