using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Ward :BaseEntity
    {
        public Ward()
        {
            Location = new HashSet<Location>();
        }

        public string WardName { get; set; }
        public bool? IsDelete { get; set; }
        public string DistrictId { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
