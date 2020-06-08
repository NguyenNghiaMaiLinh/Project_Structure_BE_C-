using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
    public interface IFollowerService
    {
        BaseViewModel<FollowerViewPage> follow(FollowerCreateViewPage request);
        BaseViewModel<FollowerViewPage> unfollow(FollowerCreateViewPage request);
        BaseViewModel<PagingResult<FollowerViewPage>> getAllFollowerByAuthor();
    }
}
