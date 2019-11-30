using MyApp.Core.Data.Infrastructure;
using Task = MyApp.Core.Data.Entity.Task;

namespace MyApp.Core.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
    }
}
