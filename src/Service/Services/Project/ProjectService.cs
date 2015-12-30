using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Data.Core;
using Data.Core.EntityFramework;

namespace Service.Core
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectUserService _projectUserService;

        public ProjectService(IProjectRepository projectRepository, IProjectUserService projectUserService)
        {
            _projectRepository = projectRepository;
            _projectUserService = projectUserService;
        }

        #region GET
        public List<ProjectListModel> GetProjectListing(string userId)
        {
            List<Project> projects = _projectRepository.GetProjectForUser(userId);
            return CustomMapper.Map<Project, ProjectListModel>(projects).ToList();
        }
        public ProjectModel GetProject(int id)
        {
            Specification<Project> specification = new Specification<Project>(x => x.Id == id);
            return GetProjects(specification).FirstOrDefault();
        }
        private IEnumerable<ProjectModel> GetProjects(Specification<Project> specification)
        {
            List<Project> projects = _projectRepository.GetProjects(specification);
            return CustomMapper.Map<Project, ProjectModel>(projects).ToList();
        }
        #endregion

        #region CREATE / MODIFY
        public void CreateNewProject(CreateProjectModel model, out int projectId)
        {
            Project project = new Project
            {
                Name = model.Name,
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now
            };

            using (TransactionScope scope = new TransactionScope())
            {
                _projectRepository.CreateNewProject(project, out projectId);
                _projectUserService.AddUsersToProject(projectId, model.Users);
                scope.Complete();
            }
        }
        #endregion
    }
}
