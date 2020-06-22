using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

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
