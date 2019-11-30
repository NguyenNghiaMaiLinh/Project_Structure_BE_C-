using MyApp.Core.Constaint;
using System.ComponentModel.DataAnnotations;

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
}
