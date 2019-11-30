using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Core.Service
{
    public interface IWorkflowMemberService
    {
        BaseViewModel<WorkflowMemberViewPage> addMember(WorkflowMemberCreateViewPage request);
    }
}
