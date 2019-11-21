using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;

namespace MyApp.Repository.Repository
{
    public class WorkflowMembersRepository : RepositoryBase<WorkflowMember>, IWorkflowMembersRepository
    {
        private DataContext _dataContext;
        public WorkflowMembersRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

    }
}
