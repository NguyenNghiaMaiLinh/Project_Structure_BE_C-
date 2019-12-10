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
    public class UserRepository : RepositoryBase<Account>, IUserRepository
    {
        private DataContext _dataContext;
        public UserRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Account> getAllUser(int? pageIndex, int? pageSize)
        {
            var par1 = new SqlParameter("@PageIndex", pageIndex);
            var par2 = new SqlParameter("@PageSize", pageSize);

            return _dataContext.Account.FromSql("getAllUser @PageIndex, @PageSize", par1, par2).ToList();
        }

        public IEnumerable<Account> searchUser(string search)
        {
            return _dataContext.Account.Where(a => a.Username.Contains(search));
        }
    }
}
