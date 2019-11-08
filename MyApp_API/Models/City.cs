using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class City
    {
        public City()
        {
            District = new HashSet<District>();
        }

        public string Id { get; set; }
        public string CityName { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
