using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;

namespace MyApp.Core.Repository
{
    public interface ICategoryProductRepository : IRepository<CategoryProduct>
    {
        CategoryProduct getByProductId(string productId);  
    }
}
