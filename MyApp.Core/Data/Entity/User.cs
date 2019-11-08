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

        public User()
        {
            DiscountUser = new HashSet<DiscountUser>();
            Location = new HashSet<Location>();
            Order = new HashSet<Order>();
        }

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
        public string Role { get; set; }

        public virtual ICollection<DiscountUser> DiscountUser { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
