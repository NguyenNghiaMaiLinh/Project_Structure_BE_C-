using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IWorkflowMembersRepository : IRepository<WorkflowMember>
    {
        WorkflowMember checkExisted(string member, string workflow);
        IEnumerable<Account> getAllMemberByWorkflowId(int? pageIndex, int? pageSize, string userId, string search);
    }
}
