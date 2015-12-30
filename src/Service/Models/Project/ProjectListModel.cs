namespace Service.Core
{
    public class ProjectListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public string UpdatedDateTimeMoment { get; set; }
        public int MemberCount { get; set; }
    }
}