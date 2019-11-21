using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class WorkflowMember
    {
        public WorkflowMember()
        {
            Comment = new HashSet<Comment>();
            TaskAssignee = new HashSet<TaskAssignee>();
        }

        public string Id { get; set; }
        public string WorkflowMainId { get; set; }
        public string UserId { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        public virtual Account User { get; set; }
        public virtual Workflow WorkflowMain { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<TaskAssignee> TaskAssignee { get; set; }
    }
}
