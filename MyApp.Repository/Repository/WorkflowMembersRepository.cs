using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
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
            var check = _dataContext.WorkflowMember.FirstOrDefault(w => w.UserId == member && w.WorkflowMainId == workflow && w.IsDelete == false);
            if (check == null)
            {
                return null;
            }
            else
            {
                return check;
            }
        }

        public IEnumerable<WorkflowMember> getAllMemberByWorkflowId(string workflowId)
        {
            //if (search == null)
            //{
            //    search = "";
            //}
            //var par1 = new SqlParameter("@PageIndex", pageIndex);
            //var par2 = new SqlParameter("@PageSize", pageSize);
            //var par3 = new SqlParameter("@WorkflowId", workflowId);
            //var par4 = new SqlParameter("@Search", search);

            var result = _dataContext.WorkflowMember.Where(m => m.WorkflowMainId == workflowId && m.IsDelete == false);
            return result;
        }
        public WorkflowMember getMemberId(string workflowId, string username)
        {
            var result = _dataContext.WorkflowMember.FirstOrDefault(m => m.WorkflowMainId == workflowId && m.UserId == username && m.IsDelete == false);
            return result;
        }
    }
}
