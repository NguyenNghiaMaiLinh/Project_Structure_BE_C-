using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
    public interface ICategoryService
    {
        BaseViewModel<PagingResult<CategoryViewPage>> GetAllCategory (BasePagingRequestViewModel request);
    }
}
