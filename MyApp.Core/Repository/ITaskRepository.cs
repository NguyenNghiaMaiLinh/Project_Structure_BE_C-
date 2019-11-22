using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MyApp.Core.Data.Entity.Task;

namespace MyApp.Core.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {

    }
}
