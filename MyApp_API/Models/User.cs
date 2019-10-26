using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class User
    {
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
        public int? Phone { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
    }
}
