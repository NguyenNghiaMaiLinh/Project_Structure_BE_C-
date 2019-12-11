using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.DTO;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        private DataContext _dataContext;
        public CommentRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Comment> getAllComment(int? pageIndex, int? pageSize, string taskId, string search)
        {
            //if (search == null)
            //{
            //    search = "";
            //}
            //var par1 = new SqlParameter("@PageIndex", pageIndex);
            //var par2 = new SqlParameter("@PageSize", pageSize);
            //var par3 = new SqlParameter("@TaskId", taskId);
            //var par4 = new SqlParameter("@Search", search);

            //var result = _dataContext.Comment.FromSql("getAllComment @PageIndex, @PageSize, @TaskId, @Search", par1, par2, par3, par4).ToList();
            //return result;
            var result = _dataContext.Comment.Where(c => c.TaskId == taskId && c.IsDelete == false);
            return result;
        }

    }
}
