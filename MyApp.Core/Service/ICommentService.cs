using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Threading.Tasks;

namespace MyApp.Core.Service
{
    public interface ICommentService
    {
        BaseViewModel<PagingResult<CommentViewPage>> getAllComment(CommentPagingRequestViewModel request);
        BaseViewModel<CommentViewPage> getCommentById(string id);
        Task<BaseViewModel<CommentViewPage>> create(CommentCreateViewPage request);
        BaseViewModel<string> getMemberId(string workflowId);
        BaseViewModel<CommentViewPage> update(CommentUpdateViewPage request);
        BaseViewModel<bool> delete(string id);
    }
}
