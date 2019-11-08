namespace MyApp.Core.Data.Entity
{
    public partial class CategoryProduct :BaseEntity
    {
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }

        public bool? IsDelete { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
