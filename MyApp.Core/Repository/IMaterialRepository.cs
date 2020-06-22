using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IMaterialRepository : IRepository<Material>
    {
        IEnumerable<Material> getALlMaterialByRecipeId(string id);
    }
}
