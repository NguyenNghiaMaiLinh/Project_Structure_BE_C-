using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Task
    {
        public Task()
        {
            Comment = new HashSet<Comment>();
            InverseTaskMain = new HashSet<Task>();
            TaskAssignee = new HashSet<TaskAssignee>();
        }

        public string Id { get; set; }
        public string WorkflowId { get; set; }
        public string TaskName { get; set; }
        public bool? IsDelete { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsMain { get; set; }
        public string TaskMainId { get; set; }
        public int? Status { get; set; }
        public int? PositionInWorkflow { get; set; }

        public virtual Task TaskMain { get; set; }
        public virtual Workflow Workflow { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Task> InverseTaskMain { get; set; }
        public virtual ICollection<TaskAssignee> TaskAssignee { get; set; }
    }
}
