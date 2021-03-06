﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProjectManagementEntities : DbContext
    {
        public ProjectManagementEntities()
            : base("name=ProjectManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<UserProjectMapping> UserProjectMappings { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<IssuePriorityMaster> IssuePriorityMasters { get; set; }
        public virtual DbSet<IssueStatusMaster> IssueStatusMasters { get; set; }
        public virtual DbSet<IssueTypeMaster> IssueTypeMasters { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
    
        public virtual ObjectResult<GetUsersInProjectResult> get_users_in_project(Nullable<int> project_id)
        {
            var project_idParameter = project_id.HasValue ?
                new ObjectParameter("project_id", project_id) :
                new ObjectParameter("project_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUsersInProjectResult>("get_users_in_project", project_idParameter);
        }
    }
}
