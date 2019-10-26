using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Data.Entity
{
    public partial class User: BaseEntity
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarPath { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public int? Phone { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
    }
}
