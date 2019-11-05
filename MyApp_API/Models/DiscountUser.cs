using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class DiscountUser
    {
        public string Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }
        public string UserId { get; set; }
        public string DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual User User { get; set; }
    }
}
