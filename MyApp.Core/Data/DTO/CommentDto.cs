using MyApp.Core.Data.Entity;

namespace MyApp.Core.Data.DTO
{
    public class CommentDto : BaseEntity
    {
        public string WorkflowMemberId { get; set; }
        public string TaskId { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }
        public string Username { get; set; }
    }
}
