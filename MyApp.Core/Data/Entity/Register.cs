using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Register 
    {
        public Register()
        {
            FollowerAuthor = new HashSet<Follower>();
            FollowerFollowerNavigation = new HashSet<Follower>();
        }

        public string Username { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Avartar { get; set; }
        public string Cover { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Follower> FollowerAuthor { get; set; }
        public virtual ICollection<Follower> FollowerFollowerNavigation { get; set; }
    }
}
