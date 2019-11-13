using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMembers>();
            TaskCategory = new HashSet<TaskCategory>();
        }

        public string Id { get; set; }
        public string ProjectName { get; set; }
        public int? Status { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }

        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        public virtual ICollection<TaskCategory> TaskCategory { get; set; }
    }
}
