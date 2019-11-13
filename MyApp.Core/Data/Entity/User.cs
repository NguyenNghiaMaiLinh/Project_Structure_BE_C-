using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.Data.Entity
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            ProjectMembers = new HashSet<ProjectMembers>();
            TaskAssignee = new HashSet<TaskAssignee>();
        }
        [Key]
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public bool? IsDelete { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        public virtual ICollection<TaskAssignee> TaskAssignee { get; set; }
    }
}
