using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
