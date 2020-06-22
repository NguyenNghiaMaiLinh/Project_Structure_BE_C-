using System;

namespace MyApp.Core.Data.Entity
{
    public partial class Material : BaseEntity
    {
        public string Name { get; set; }
        public double? Quantity { get; set; }
        public string Unit { get; set; }
        public string RecipeId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
