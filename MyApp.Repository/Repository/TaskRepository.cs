using EFCore.BulkExtensions;
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
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        private DataContext _dataContext;
        public TaskRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public void addBulk(IEnumerable<Task> list)
        {
            _dataContext.BulkInsert(list.ToList());
        }

        public IEnumerable<Task> getAllTask(int? pageIndex, int? pageSize, string search)
        {
            if (search == null)
            {
                search = "";
            }
            var par1 = new SqlParameter("@PageIndex", pageIndex);
            var par2 = new SqlParameter("@PageSize", pageSize);
            var par3 = new SqlParameter("@Search", search);

            var result = _dataContext.Task.FromSql("getAllTask @PageIndex, @PageSize, @Search", par1, par2, par3).ToList(); ;
            return result;
        }
    }
}
