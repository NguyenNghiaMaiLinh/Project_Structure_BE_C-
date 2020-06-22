using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class MaterialRepository : RepositoryBase<Material>, IMaterialRepository
    {
        private DataContext _dataContext;
        public MaterialRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Material> getALlMaterialByRecipeId(string id)
        {
            var result = _dataContext.Material.Where(f => f.RecipeId == id && f.IsDelete == false);
            return result;
        }
    }
}
