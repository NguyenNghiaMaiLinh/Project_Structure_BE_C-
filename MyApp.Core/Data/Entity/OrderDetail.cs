using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class OrderDetail :BaseEntity
    {

        public bool? IsDelete { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
