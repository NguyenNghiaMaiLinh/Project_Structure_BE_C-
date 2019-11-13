using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Comment: BaseEntity
    { 
        public string UserId { get; set; }
        public string TaskItemId { get; set; }
        public bool? IsDelete { get; set; }
        public string Detail { get; set; }

        public virtual TaskItem TaskItem { get; set; }
        public virtual User User { get; set; }
    }
}
