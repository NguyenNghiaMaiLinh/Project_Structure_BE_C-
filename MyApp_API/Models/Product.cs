using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Product
    {
        public Product()
        {
            CategoryProduct = new HashSet<CategoryProduct>();
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
        public bool? IsNew { get; set; }
        public int? Sale { get; set; }
        public decimal? Rating { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
