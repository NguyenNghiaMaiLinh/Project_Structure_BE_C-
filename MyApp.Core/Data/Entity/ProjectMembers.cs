using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class ProjectMembers: BaseEntity
    {
        public string ProjectId { get; set; }
        public string UserId { get; set; }
        public bool? IsDelete { get; set; }


        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
