//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Core.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issue
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<byte> Type { get; set; }
        public Nullable<byte> Priority { get; set; }
        public Nullable<byte> Status { get; set; }
        public string ReportedBy { get; set; }
        public System.DateTime ReportedDate { get; set; }
        public string AssignedTo { get; set; }
        public string ModifedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual IssuePriorityMaster IssuePriorityMaster { get; set; }
        public virtual IssueStatusMaster IssueStatusMaster { get; set; }
        public virtual IssueTypeMaster IssueTypeMaster { get; set; }
        public virtual Project Project { get; set; }
    }
}