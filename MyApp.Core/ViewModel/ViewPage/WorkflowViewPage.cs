using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class WorkflowViewPage
    {
        public string Id { get; set; }
        public string WorkflowName { get; set; }

    }

    public partial class WorkflowCreateViewPage
    {
        public string WorkflowName { get; set; }
    }
    public partial class WorkflowCreateInstanceViewPage
    {
        public string Id { get; set; }
        public string WorkflowName { get; set; }
    }
    public partial class WorkflowUpdateViewPage
    {
        public string Id { get; set; }
        public string WorkflowName { get; set; }

    }
    public partial class WorkflowDeleteViewPage
    {
        public string id { get; set; }
    }
}
