using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Ward
    {
        public Ward()
        {
            Location = new HashSet<Location>();
        }

        public string Id { get; set; }
        public string WardName { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
