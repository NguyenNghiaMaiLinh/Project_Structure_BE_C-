using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;

namespace MyApp.Repository.Repository
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        private DataContext _dataContext;
        public DistrictRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }
    }
}
