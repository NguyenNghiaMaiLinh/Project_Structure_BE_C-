using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string ProductName { get; set; }
        public string ItemCategoryId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
