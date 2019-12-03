using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class WorkflowMemberViewPage
    {
        public string Id { get; set; }
        public string WorkflowMainId { get; set; }
        public string UserId { get; set; }
        public string CreateBy { get; set; }
        public string CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateAt { get; set; }
    }
    public partial class WorkflowMemberCreateViewPage
    {
        public string WorkflowMainId { get; set; }
        public string UserId { get; set; }
    }
}
