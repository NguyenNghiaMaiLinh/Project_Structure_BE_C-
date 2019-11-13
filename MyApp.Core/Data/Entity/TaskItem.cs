using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class TaskItem: BaseEntity
    {
        public TaskItem()
        {
            Activity = new HashSet<Activity>();
            Comment = new HashSet<Comment>();
            TaskAssignee = new HashSet<TaskAssignee>();
        }
        public string TaskCategoryId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public virtual TaskCategory TaskCategory { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<TaskAssignee> TaskAssignee { get; set; }
    }
}
