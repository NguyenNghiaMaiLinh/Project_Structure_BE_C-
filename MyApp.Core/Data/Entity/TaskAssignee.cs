using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class TaskAssignee :BaseEntity
    {
        public string WorkflowMemberId { get; set; }
        public string TaskId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Task Task { get; set; }
        public virtual WorkflowMember WorkflowMember { get; set; }
    }
}
