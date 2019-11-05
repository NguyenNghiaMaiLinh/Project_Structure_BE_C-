using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class User
    {
        public User()
        {
            DiscountUser = new HashSet<DiscountUser>();
            Location = new HashSet<Location>();
            Order = new HashSet<Order>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<DiscountUser> DiscountUser { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
