using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class TaskCategory: BaseEntity
    {
        public TaskCategory()
        {
            TaskItem = new HashSet<TaskItem>();
        }

        public string ProjectId { get; set; }
        public string TaskCategoryName { get; set; }
        public bool? IsDelete { get; set; }


        public virtual Project Project { get; set; }
        public virtual ICollection<TaskItem> TaskItem { get; set; }
    }
}
