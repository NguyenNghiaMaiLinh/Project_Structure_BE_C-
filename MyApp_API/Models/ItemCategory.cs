using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Product = new HashSet<Product>();
        }

        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string ItemCategoryName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
