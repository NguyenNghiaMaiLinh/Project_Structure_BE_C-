using MyApp.Core.Constaint;
using System;


namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class WorkflowViewPage
    {
        public string Id { get; set; }
        public string WorkflowName { get; set; }
        public int? TotalTask { get; set; }
        public bool? IsMain { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Status { get; set; }
        public int DoneTask { get; set; }
    }

    public partial class WorkflowCreateViewPage
    {
        public string WorkflowName { get; set; }
        public string Description { get; set; }
    }
    public partial class WorkflowCreateInstanceViewPage
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public partial class WorkflowChangeStatusViewPage
    {
        public MyEnum.Status Status { get; set; }
    }
    public partial class WorkflowUpdateViewPage
    {
        public string Id { get; set; }
        public string WorkflowName { get; set; }
        public MyEnum.Status Status { get; set; }
        public string Description { get; set; }
    }
    public partial class WorkflowDeleteViewPage
    {
        public string id { get; set; }
    }
}
