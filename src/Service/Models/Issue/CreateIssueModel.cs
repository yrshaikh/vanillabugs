using System;

namespace Service.Core
{
    public class CreateIssueModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? Type { get; set; }
        public byte? Priority { get; set; }
        public byte? Status { get; set; }
        public string ReportedBy { get; set; }
        public DateTime ReportedDate { get; set; }
        public string AssignedTo { get; set; }
        public string ModifedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
