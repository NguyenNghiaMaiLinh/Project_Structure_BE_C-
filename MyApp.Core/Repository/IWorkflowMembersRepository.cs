using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;

namespace MyApp.Core.Repository
{
    public interface IWorkflowMembersRepository : IRepository<WorkflowMember>
    {
        WorkflowMember checkExisted(string member, string workflow);
    }
}
