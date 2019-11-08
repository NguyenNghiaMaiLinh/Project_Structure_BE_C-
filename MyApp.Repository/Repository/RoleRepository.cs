using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private DataContext _dataContext;
        public RoleRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

    }
}
