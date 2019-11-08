using System.Collections.Generic;

namespace MyApp.Core.Data.Entity
{
    public partial class ItemCategory :BaseEntity
    {
        public ItemCategory()
        {
            Product = new HashSet<Product>();
        }
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }

        public bool? IsDelete { get; set; }
        public string ItemCategoryName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
