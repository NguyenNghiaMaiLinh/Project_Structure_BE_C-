using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Account
    {
        public Account()
        {
            Workflow = new HashSet<Workflow>();
            WorkflowMember = new HashSet<WorkflowMember>();
        }

        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public bool? IsDelete { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string DeviceToken { get; set; }

        public virtual ICollection<Workflow> Workflow { get; set; }
        public virtual ICollection<WorkflowMember> WorkflowMember { get; set; }
    }
}
