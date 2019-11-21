using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Category :BaseEntity
    {
        public Category()
        {
            Workflow = new HashSet<Workflow>();
        }

        public string CategoryName { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Workflow> Workflow { get; set; }
    }
}
