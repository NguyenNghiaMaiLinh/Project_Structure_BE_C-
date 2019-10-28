using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class User : BaseEntity
    {
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
