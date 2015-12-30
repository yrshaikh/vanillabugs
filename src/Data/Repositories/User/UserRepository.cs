using System.Collections.Generic;
using System.Linq;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public class UserRepository : IUserRepository
    {
        public List<AspNetUser> GetUsers(Specification<AspNetUser> specification)
        {
            using (var dbContext = new ProjectManagementEntities())
            {
                return specification.SatisfyingEntitiesFrom(dbContext.AspNetUsers).ToList();
            }
        }
    }
}
