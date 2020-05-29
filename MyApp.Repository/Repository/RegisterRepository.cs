using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;

namespace MyApp.Repository.Repository
{
    public class RegisterRepository : RepositoryBase<Register>, IRegisterRepository
    {
        private DataContext _dataContext;
        public RegisterRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }
    }
}
