using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;

namespace MyApp.Repository.Repository
{
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        private DataContext _dataContext;
        public BannerRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }
    }
}
