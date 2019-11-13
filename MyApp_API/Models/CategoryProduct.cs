using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class CategoryProduct
    {
        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
