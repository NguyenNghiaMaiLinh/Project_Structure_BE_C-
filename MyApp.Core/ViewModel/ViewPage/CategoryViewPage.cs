using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public class CategoryViewPage
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryCreateViewPage
    {
        public string CategoryName { get; set; }
    }
    public class CategoryUpdateViewPage
    {
        public string CategoryName { get; set; }
    }
}
