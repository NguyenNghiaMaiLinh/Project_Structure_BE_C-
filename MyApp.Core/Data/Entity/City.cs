using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class City :BaseEntity
    {
        public City()
        {
            District = new HashSet<District>();
        }

        public string CityName { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
