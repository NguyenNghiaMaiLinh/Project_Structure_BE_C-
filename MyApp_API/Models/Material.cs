using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Material
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? Quantity { get; set; }
        public string Unit { get; set; }
        public string RecipeId { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
