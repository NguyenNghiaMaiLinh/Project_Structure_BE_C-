using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private DataContext _dataContext;
        public UserRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        //public User GetByUsername(string username)
        //{
        //    var user =_dataContext.User.FirstOrDefault(u => u.Username == username && u.IsDelete == false);
        //    return user;
        //}

    }
}
