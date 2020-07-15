using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Core.Data.Entity
{
    public partial class Register
    {
        public Register()
        {
            FollowerAuthor = new HashSet<Follower>();
            FollowerFollowerNavigation = new HashSet<Follower>();
        }

        [Key]
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Role { get; set; }
        [StringLength(100)]
        public string Fullname { get; set; }
        [StringLength(1000)]
        public string HashPassword { get; set; }
        [StringLength(500)]
        public string SaltPassword { get; set; }
        [StringLength(500)]
        public string Avartar { get; set; }
        [StringLength(500)]
        public string Cover { get; set; }
        [Column("Is_Delete")]
        public bool? IsDelete { get; set; }
        [Column("Device_Token")]
        [StringLength(500)]
        public string DeviceToken { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Follower> FollowerAuthor { get; set; }
        [InverseProperty("FollowerNavigation")]
        public virtual ICollection<Follower> FollowerFollowerNavigation { get; set; }

    }
}
