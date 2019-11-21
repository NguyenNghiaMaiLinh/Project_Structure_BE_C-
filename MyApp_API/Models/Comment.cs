using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Comment
    {
        public string Id { get; set; }
        public string WorkflowMemberId { get; set; }
        public string TaskId { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }

        public virtual Task Task { get; set; }
        public virtual WorkflowMember WorkflowMember { get; set; }
    }
}
