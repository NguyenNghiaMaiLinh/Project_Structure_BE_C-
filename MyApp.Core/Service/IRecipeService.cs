using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
    public interface IRecipeService
    {
        BaseViewModel<PagingResult<RecipeViewPage>> getAllRecipeByAuthor();
        BaseViewModel<RecipeViewPage> getRecipeById(string id);
        BaseViewModel<RecipeViewPage> create(RecipeCreateViewPage request);
        BaseViewModel<RecipeViewPage> update(RecipeUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
