using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class TaskViewPage
    {
        public string Id { get; set; }
        public string WorkflowId { get; set; }
        public string TaskName { get; set; }
        public bool? IsMain { get; set; }
        public string TaskMainId { get; set; }
        public int? Status { get; set; }
        public int? PositionInWorkflow { get; set; }
    }
    public class TaskCreateViewPage
    {
        public string WorkflowId { get; set; }
        public string TaskName { get; set; }
        public bool? IsMain { get; set; }
        public string TaskMainId { get; set; }
        public int? Status { get; set; }
        public int? PositionInWorkflow { get; set; }
    }
    public class TaskUpdateViewPage
    {
        public string TaskName { get; set; }
        public int? Status { get; set; }
        public int? PositionInWorkflow { get; set; }
    }
}
