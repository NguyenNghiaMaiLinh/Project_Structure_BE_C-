using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class WorkflowMember:BaseEntity
    {
        public WorkflowMember()
        {
            Comment = new HashSet<Comment>();
            TaskAssignee = new HashSet<TaskAssignee>();
        }

        public string WorkflowMainId { get; set; }
        public string UserId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Account User { get; set; }
        public virtual Workflow WorkflowMain { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<TaskAssignee> TaskAssignee { get; set; }
    }
}
