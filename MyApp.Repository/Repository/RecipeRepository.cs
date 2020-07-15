using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        private DataContext _dataContext;
        public RecipeRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public int countRecipe(string author)
        {
            var result = _dataContext.Recipe.Count<Recipe>(r => r.CreateBy == author && r.IsDelete == false);
            return result;
        }

        public IEnumerable<Recipe> getAllRecipe(int? pageIndex, int? pageSize, string search, string author)
        {
            //if (search == null)
            //{
            //    search = "";
            //}
            //var par1 = new SqlParameter("@PageIndex", pageIndex);
            //var par2 = new SqlParameter("@PageSize", pageSize);
            //var par3 = new SqlParameter("@Search", search);
            //var par4 = new SqlParameter("@Author", author);

            //var result = _dataContext.Recipe.FromSql("getAllRecipe @PageIndex, @PageSize, @Search, @Author", par1, par2, par3, par4).ToList();

            //var result = _dataContext.Comment.Where(c => c.TaskId == taskId && c.IsDelete == false);
            return null;
        }

        public IEnumerable<Recipe> getAllRecipeByAuthor(string author)
        {
            var result = _dataContext.Recipe.Where(c => c.CreateBy == author && c.IsDelete == false);
            return result;
        }

        public IEnumerable<Recipe> getAllRecipeSuggestion()
        {
            //if (search == null)
            //{
            //    search = "";
            //}
            //var par1 = new SqlParameter("@PageIndex", pageIndex);
            //var par2 = new SqlParameter("@PageSize", pageSize);
            //var par3 = new SqlParameter("@Search", search);
            //var par4 = new SqlParameter("@Author", author);

            //var result = _dataContext.Recipe.FromSql("getAllRecipe @PageIndex, @PageSize, @Search, @Author", par1, par2, par3, par4).ToList();

            var result = _dataContext.Recipe.Where(c => c.IsDelete == false);
            return result;
        }

    }
}
