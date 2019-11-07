namespace MyApp.Core.Data.Entity
{
    public partial class Location :BaseEntity
    {
        public string AddressName { get; set; }
        public bool? IsDelete { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WardId { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Ward Ward { get; set; }
    }
}
