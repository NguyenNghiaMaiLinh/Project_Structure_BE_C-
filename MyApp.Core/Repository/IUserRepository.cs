using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IUserRepository : IRepository<Account>
    {
        IEnumerable<Account> getAllUser(int? pageIndex, int? pageSize);
        IEnumerable<Account> searchUser(string search);
    }
}
