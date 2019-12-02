using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Core.Service
{
    public interface IWorkflowMemberService
    {
        BaseViewModel<WorkflowMemberViewPage> addMember(WorkflowMemberCreateViewPage request);
        BaseViewModel<PagingResult<Account>> getAllMember(MemberPagingRequestViewModel request);
    }
}
