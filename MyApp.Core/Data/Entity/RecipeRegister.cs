namespace MyApp.Core.Data.Entity
{
    public partial class RecipeRegister:BaseEntity
    {
        public string RecipeId { get; set; }
        public string Saver { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
