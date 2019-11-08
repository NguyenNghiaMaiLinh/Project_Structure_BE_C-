using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Location
    {
        public string Id { get; set; }
        public string AddressName { get; set; }
        public bool? IsDelete { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WardId { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Ward Ward { get; set; }
    }
}
