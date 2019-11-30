namespace MyApp.Core.Data.Entity
{
    public partial class Comment : BaseEntity
    {
        public string WorkflowMemberId { get; set; }
        public string TaskId { get; set; }
        public bool? IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }

        public virtual Task Task { get; set; }
        public virtual WorkflowMember WorkflowMember { get; set; }
    }
}
