namespace MyApp.Core.Data.Entity
{
    public partial class Step : BaseEntity
    {
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public bool? IsRepair { get; set; }
        public string RecipeId { get; set; }
        public string Video { get; set; }
       
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
