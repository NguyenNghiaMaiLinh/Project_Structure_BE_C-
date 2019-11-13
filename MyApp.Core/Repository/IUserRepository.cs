using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        //User GetByUsername(string username);
    }
}
