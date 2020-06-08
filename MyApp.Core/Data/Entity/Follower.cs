namespace MyApp.Core.Data.Entity
{
    public partial class Follower : BaseEntity
    {
        public string AuthorId { get; set; }
        public string FollowerId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Register Author { get; set; }
        public virtual Register FollowerNavigation { get; set; }
    }
}