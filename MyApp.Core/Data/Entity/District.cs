using System;
using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class District :BaseEntity
    {
        public District()
        {
            Ward = new HashSet<Ward>();
        }
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }


        public string DistrictName { get; set; }
        public bool? IsDelete { get; set; }
        public string CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Ward> Ward { get; set; }
    }
}
