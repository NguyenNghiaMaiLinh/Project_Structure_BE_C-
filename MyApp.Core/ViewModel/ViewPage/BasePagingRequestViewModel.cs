using MyApp.Core.Constaint;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public class BasePagingRequestViewModel
    {

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int? PageSize { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int? PageIndex { get; set; }
        public string Search { get; set; }
        public void SetDefaultPage()
        {
            PageSize = PageSize ?? Constants.DEFAULT_PAGE_SIZE;
            PageIndex = PageIndex ?? Constants.DEFAULT_PAGE_INDEX;
            PageSize = PageSize > Constants.MAX_PAGE_SIZE ? Constants.MAX_PAGE_SIZE : PageSize;
        }

    }
    public class ProductPagingRequestModel : BasePagingRequestViewModel
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class BaseRequestViewModel
    {
        public string Search { get; set; }
    }
}
