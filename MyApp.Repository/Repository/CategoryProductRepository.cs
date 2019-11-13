using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class CategoryProductRepository : RepositoryBase<CategoryProduct>, ICategoryProductRepository
    {
        private DataContext _dataContext;
        public CategoryProductRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public CategoryProduct getByProductId(string productId)
        {
            return _dataContext.CategoryProduct.FirstOrDefault(p => p.ProductId == productId && p.IsDelete == false);
        }
    }
}
