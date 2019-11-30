using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> getAllComment(int? pageIndex, int? pageSize, string taskId, string search);
    }
}
