using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Register
    {
        public Register()
        {
            FollowerAuthorNavigation = new HashSet<Follower>();
            FollowerFollower1Navigation = new HashSet<Follower>();
        }

        public string Username { get; set; }
        public string Role { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Avarter { get; set; }
        public string Cover { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Follower> FollowerAuthorNavigation { get; set; }
        public virtual ICollection<Follower> FollowerFollower1Navigation { get; set; }
    }
}
