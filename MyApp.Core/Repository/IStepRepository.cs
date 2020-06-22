using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IStepRepository : IRepository<Step>
    {
        IEnumerable<Step> getALlStepByRecipeId(string id);
    }
}
