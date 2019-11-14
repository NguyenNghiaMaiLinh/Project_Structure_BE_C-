using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class ProjectMembers
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        public virtual Project Project { get; set; }
        public virtual Users User { get; set; }
    }
}
