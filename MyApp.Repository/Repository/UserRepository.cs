using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.Repository
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        private DataContext _dataContext;
        public UserRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Users> getAllUser(int? pageIndex, int? pageSize)
        {
            var par1 = new SqlParameter("@PageIndex", pageIndex);
            var par2 = new SqlParameter("@PageSize", pageSize);

            return _dataContext.Users.FromSql("getAllUser @PageIndex, @PageSize", par1, par2).ToList();
        }
    }
}
