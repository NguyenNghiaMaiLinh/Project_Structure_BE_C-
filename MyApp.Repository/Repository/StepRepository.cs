using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class StepRepository : RepositoryBase<Step>, IStepRepository
    {
        private DataContext _dataContext;
        public StepRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Step> getALlStepByRecipeId(string id)
        {
            var result = _dataContext.Step.Where(f => f.RecipeId == id && f.IsDelete == false);
            return result;
        }
    }
}
