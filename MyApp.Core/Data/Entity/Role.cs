using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Role :BaseEntity
    {
        public Role()
        {
            User = new HashSet<User>();
        }
     
        public string Name { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
