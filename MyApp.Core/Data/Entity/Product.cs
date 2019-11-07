using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Product :BaseEntity
    {
        public Product()
        {
            CategoryProduct = new HashSet<CategoryProduct>();
            OrderDetail = new HashSet<OrderDetail>();
        }

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
        public string MadeIn { get; set; }
        public string TradeMark { get; set; }
        public string ProvidedBy { get; set; }
        public string WarrantyPeriod { get; set; }
        public string Material { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
