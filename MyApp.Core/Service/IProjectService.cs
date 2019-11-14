using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
   public interface IProjectService
    {
        BaseViewModel<PagingResult<ProjectViewPage>> GetAllProject(BasePagingRequestViewModel request);
        BaseViewModel<ProjectViewPage> create(ProjectCreateViewPage request);
        BaseViewModel<ProjectViewPage> update(string id, ProjectUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
