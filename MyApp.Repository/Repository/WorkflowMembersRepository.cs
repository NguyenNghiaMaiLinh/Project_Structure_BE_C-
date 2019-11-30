using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class WorkflowMembersRepository : RepositoryBase<WorkflowMember>, IWorkflowMembersRepository
    {
        private DataContext _dataContext;
        public WorkflowMembersRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public WorkflowMember checkExisted(string member, string workflow)
        {
            var check =_dataContext.WorkflowMember.FirstOrDefault(w => w.UserId == member && w.WorkflowMainId == workflow && w.IsDelete == false);
            if(check == null)
            {
                return null;
            }
            else
            {
                return check;
            }
        }
    }
}
