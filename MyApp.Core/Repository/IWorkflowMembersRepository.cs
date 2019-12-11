using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IWorkflowMembersRepository : IRepository<WorkflowMember>
    {
        WorkflowMember checkExisted(string member, string workflow);
        IEnumerable<WorkflowMember> getAllMemberByWorkflowId(string workflowId);
        WorkflowMember getMemberId(string workflowId, string username);
    }
}
