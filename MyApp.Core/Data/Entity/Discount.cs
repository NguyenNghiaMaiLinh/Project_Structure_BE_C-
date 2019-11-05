using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Discount
    {
        public Discount()
        {
            DiscountUser = new HashSet<DiscountUser>();
        }

        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string Code { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        public virtual ICollection<DiscountUser> DiscountUser { get; set; }
    }
}
