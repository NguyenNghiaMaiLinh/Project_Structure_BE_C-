using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Workflow
    {
        public Workflow()
        {
            InverseWorkflowMain = new HashSet<Workflow>();
            Task = new HashSet<Task>();
            WorkflowMember = new HashSet<WorkflowMember>();
        }

        public string Id { get; set; }
        public string WorkflowMainId { get; set; }
        public string WorkflowName { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public bool? IsMain { get; set; }

        public virtual Account CreateByNavigation { get; set; }
        public virtual Workflow WorkflowMain { get; set; }
        public virtual ICollection<Workflow> InverseWorkflowMain { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<WorkflowMember> WorkflowMember { get; set; }
    }
}
