using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class Category :BaseEntity
    {
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }

        public Category()
        {
            CategoryProduct = new HashSet<CategoryProduct>();
        }

        public bool? IsDelete { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
    }
}
