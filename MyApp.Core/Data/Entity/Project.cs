using MyApp.Core.Constaint;
using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Project: BaseEntity
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMembers>();
            TaskCategory = new HashSet<TaskCategory>();
        }


        public string ProjectName { get; set; }
        public MyEnum.StatusProject Status { get; set; }
        public bool? IsDelete { get; set; }


        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        public virtual ICollection<TaskCategory> TaskCategory { get; set; }
    }
}
