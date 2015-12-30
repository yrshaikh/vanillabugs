using System.Collections.Generic;
using System.Linq;
using Data.Core;
using Data.Core.EntityFramework;

namespace Service.Core
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AspNetUserModel GetUser(string userId)
        {
            List<AspNetUser> users = _userRepository.GetUsers(new Specification<AspNetUser>(x => x.Id == userId));
            AspNetUser currentUser = users.FirstOrDefault();
            return CustomMapper.Map<AspNetUser, AspNetUserModel>(currentUser);
        }
    }
}
