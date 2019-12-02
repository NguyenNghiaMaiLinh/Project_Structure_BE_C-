using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;
using Task = MyApp.Core.Data.Entity.Task;

namespace MyApp.Core.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> getAllTask(int? pageIndex, int? pageSize, string search);
        void addBulk(IEnumerable<Task> list);
    }
}
