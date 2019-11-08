using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Discount :BaseEntity
    {
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }

        public Discount()
        {
            DiscountUser = new HashSet<DiscountUser>();
        }

        public bool? IsDelete { get; set; }
        public string Code { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }

        public virtual ICollection<DiscountUser> DiscountUser { get; set; }
    }
}
