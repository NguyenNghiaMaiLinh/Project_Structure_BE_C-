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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private DataContext _dataContext;
        public ProductRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> GetAllProductByCategoryId(string categoryId, string categoryName, string search)
        {
            var param1 = new SqlParameter("@CategoryId", categoryId);
            var param2 = new SqlParameter("@CategoryName", categoryName);
            if (search == null || search.Length == 0)
            {
                search = "";
            }
            var param3 = new SqlParameter("@Search", search);

            return _dataContext.Product.FromSql("getAllProductByCategoryId @CategoryId, @CategoryName, @Search", param1, param2, param3).ToList();
        }
    }
}
