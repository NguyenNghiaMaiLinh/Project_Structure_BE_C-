using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public string Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public string LocationId { get; set; }
        public int? TotalQuantity { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
