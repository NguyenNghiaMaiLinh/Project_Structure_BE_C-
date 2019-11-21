using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.Repository
{
    public class WorkflowRepository : RepositoryBase<Workflow>, IWorkflowRepository
    {
        private DataContext _dataContext;
        public WorkflowRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Workflow> GetAllProject(int? pageIndex, int? pageSize, string userId)
        {
            var par1 = new SqlParameter("@PageIndex", pageIndex);
            var par2 = new SqlParameter("@PageSize", pageSize);
            var par3 = new SqlParameter("@UserId", userId);

            return _dataContext.Workflow.FromSql("getAllProject @PageIndex, @PageSize, @UserId", par1, par2, par3).ToList();
        }
    }
}
