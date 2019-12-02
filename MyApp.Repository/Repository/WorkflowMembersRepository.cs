using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<Account> getAllMemberByWorkflowId(int? pageIndex, int? pageSize, string userId, string search)
        {
            if (search == null)
            {
                search = "";
            }
            var par1 = new SqlParameter("@PageIndex", pageIndex);
            var par2 = new SqlParameter("@PageSize", pageSize);
            var par3 = new SqlParameter("@WorkflowId", userId);
            var par4 = new SqlParameter("@Search", search);

            var result = _dataContext.Account.FromSql("getAllMember @PageIndex, @PageSize, @UserId, @Search", par1, par2, par3, par4).ToList(); ;
            return result;
        }
    }
}
