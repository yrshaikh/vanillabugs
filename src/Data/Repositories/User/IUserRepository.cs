using System.Collections.Generic;
using Data.Core.EntityFramework;

namespace Data.Core
{
    public interface IUserRepository
    {
        List<AspNetUser> GetUsers(Specification<AspNetUser> specification);
    }
}