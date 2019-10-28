using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
