using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Core.Service
{
    public interface ITaskService
    {
        BaseViewModel<PagingResult<TaskViewPage>> getAllTask(BasePagingRequestViewModel request);
        BaseViewModel<TaskViewPage> getTaskById(string id);
        BaseViewModel<IEnumerable<TaskViewPage>> create(TaskCreateViewPage request);
        BaseViewModel<TaskViewPage> createIntance(TaskCreateInstanceViewPage request);
        BaseViewModel<TaskViewPage> update(TaskUpdateViewPage request);
        BaseViewModel<TaskViewPage> changeStatus(string id, TaskChangeStatusViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
