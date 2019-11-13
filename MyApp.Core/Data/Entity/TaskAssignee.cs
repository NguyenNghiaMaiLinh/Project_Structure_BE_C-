using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class TaskAssignee: BaseEntity
    {
        public string TaskItemId { get; set; }
        public string AssigneeId { get; set; }
        public bool? IsDelete { get; set; }


        public virtual User Assignee { get; set; }
        public virtual TaskItem TaskItem { get; set; }
    }
}
