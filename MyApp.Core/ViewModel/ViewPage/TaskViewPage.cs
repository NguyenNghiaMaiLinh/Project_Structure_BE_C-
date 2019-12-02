using MyApp.Core.Constaint;
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
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
    public class TaskCreateViewPage
    {
        public string WorkflowId { get; set; }
        public IEnumerable<TaskRequest> tasks { get; set; }
    }
    public class TaskRequest
    {
        public string TaskName { get; set; }
        public int? PositionInWorkflow { get; set; }
    }
    public class TaskUpdateViewPage
    {
        public string Id { get; set; }
        public string TaskName { get; set; }
        public int? PositionInWorkflow { get; set; }
    }
    public class TaskChangeStatusViewPage
    {
        public MyEnum.Status Status { get; set; }

    }
}
