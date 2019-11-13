using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Activity :BaseEntity
    {
        public string TaskItemId { get; set; }
        public string ActivityName { get; set; }
        public bool? IsDelete { get; set; }

        public virtual TaskItem TaskItem { get; set; }
    }
}
