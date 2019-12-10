using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
    public interface IWorkflowMemberService
    {
        Task<BaseViewModel<WorkflowMemberViewPage>> addMember(WorkflowMemberCreateViewPage request);
        BaseViewModel<PagingResult<Account>> getAllMember(MemberPagingRequestViewModel request);
    }
}
