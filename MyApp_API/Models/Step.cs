using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Step
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public bool? IsRepair { get; set; }
        public string RecipeId { get; set; }
        public string Video { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
