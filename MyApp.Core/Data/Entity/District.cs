using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class District
    {
        public District()
        {
            Ward = new HashSet<Ward>();
        }

        public string Id { get; set; }
        public string DistrictName { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Ward> Ward { get; set; }
    }
}
