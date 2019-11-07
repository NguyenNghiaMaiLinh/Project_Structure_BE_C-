using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Order :BaseEntity
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public decimal? TotalPrice { get; set; }
        public string LocationId { get; set; }
        public int? TotalQuantity { get; set; } 
        public string Status { get; set; }
        public string UserId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
