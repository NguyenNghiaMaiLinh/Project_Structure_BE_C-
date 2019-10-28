using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class OrderDetail
    {
        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
