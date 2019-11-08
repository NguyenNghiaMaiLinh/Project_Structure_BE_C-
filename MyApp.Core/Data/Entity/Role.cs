using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Role :BaseEntity
    {
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }

        public string Name { get; set; }
        public bool? IsDelete { get; set; }

    }
}
