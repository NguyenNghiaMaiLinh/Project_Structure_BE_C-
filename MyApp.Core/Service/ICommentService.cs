using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Core.Service
{
    public interface ICommentService
    {
        BaseViewModel<PagingResult<CommentViewPage>> getAllComment(CommentPagingRequestViewModel request);
        BaseViewModel<CommentViewPage> getCommentById(string id);
        BaseViewModel<CommentViewPage> create(CommentCreateViewPage request);
        BaseViewModel<CommentViewPage> update(CommentUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
