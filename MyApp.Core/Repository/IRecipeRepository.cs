using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface IRecipeRepository :IRepository<Recipe>
    {

        IEnumerable<Recipe> getAllRecipeByAuthor(string author);
    }
}
