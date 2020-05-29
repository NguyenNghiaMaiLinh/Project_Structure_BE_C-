namespace MyApp.Core.Data.Entity
{
    public partial class Follower : BaseEntity
    {
        public string Author { get; set; }
        public string Follower1 { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Register AuthorNavigation { get; set; }
        public virtual Register Follower1Navigation { get; set; }
    }
}