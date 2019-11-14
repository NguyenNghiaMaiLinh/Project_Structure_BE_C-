using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class ProjectViewPage
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public MyEnum.StatusProject Status { get; set; }

    }

    public partial class ProjectCreateViewPage
    {
        public string ProjectName { get; set; }
    }
    public partial class ProjectUpdateViewPage
    {
        public string ProjectName { get; set; }
        public MyEnum.StatusProject Status { get; set; }
    }
    public partial class ProjectDeleteViewPage
    {
        public string id { get; set; }
    }
}
