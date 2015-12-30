using Data.Core;
using Ninject.Modules;
using Service.Core;

namespace root
{
    public class BaseBindModule : NinjectModule
    {
        public override void Load()
        {
            DataMappings();
            ServiceMappings();
        }

        public void DataMappings()
        {
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IProjectUserRepository>().To<ProjectUserRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IMasterRepository>().To<MasterRepository>();
        }

        public void ServiceMappings()
        {
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectUserService>().To<ProjectUserService>();
            Bind<IUserService>().To<UserService>();
            Bind<IMasterService>().To<MasterService>();
        }
    }
}
