using System;
using System.Collections.Generic;
using System.Linq;
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

        #region GET

        public List<object> GetProjectUsersByProjectId(int projectId)
        {
            return _projectUserRepository.GetProjectUsersByProjectId(projectId).ToList<object>();
        }
        #endregion


    }
}
