using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Core.Service
{
    public interface ITaskService
    {
        BaseViewModel<PagingResult<TaskViewPage>> getAllTask(BasePagingRequestViewModel request);
        BaseViewModel<TaskViewPage> create(TaskCreateViewPage request);
        BaseViewModel<TaskViewPage> update( TaskUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
