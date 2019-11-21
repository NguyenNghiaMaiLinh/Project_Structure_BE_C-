using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Workflow :BaseEntity
    {
        public Workflow()
        {
            InverseWorkflowMain = new HashSet<Workflow>();
            Task = new HashSet<Task>();
            WorkflowMember = new HashSet<WorkflowMember>();
        }


        public string CategoryId { get; set; }
        public string WorkflowName { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsMain { get; set; }
        public string WorkflowMainId { get; set; }
        public int? Processing { get; set; }

        public virtual Category Category { get; set; }
        public virtual Account CreateByNavigation { get; set; }
        public virtual Workflow WorkflowMain { get; set; }
        public virtual ICollection<Workflow> InverseWorkflowMain { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<WorkflowMember> WorkflowMember { get; set; }
    }
}
