namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class CommentViewPage
    {
        public string Id { get; set; }
        public string WorkflowMemberId { get; set; }
        public string TaskId { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }
    }
    public partial class CommentCreateViewPage
    {
        public string WorkflowMemberId { get; set; }
        public string TaskId { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }
    }
    public partial class CommentUpdateViewPage
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }
    }
    public partial class CommentDeleteViewPage
    {
        public string Id { get; set; }
    }
}
