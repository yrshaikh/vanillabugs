using System.Collections.Generic;

namespace Service.Core
{
    public class AppModel
    {
        public AspNetUserModel User { get; set; }
        public List<ProjectListModel> Projects { get; set; }
    }

    public class LoggedInUserDetails
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
