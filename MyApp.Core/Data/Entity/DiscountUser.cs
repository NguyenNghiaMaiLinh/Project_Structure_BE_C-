namespace MyApp.Core.Data.Entity
{
    public partial class DiscountUser :BaseEntity
    {
        public override void SetDefaultInsertValue(string username)
        {
            base.SetDefaultInsertValue(username);
        }

        public bool? IsDelete { get; set; }
        public string UserId { get; set; }
        public string DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual User User { get; set; }
    }
}
