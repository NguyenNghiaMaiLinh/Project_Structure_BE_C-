using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;

namespace MyApp.Core.Service
{
    public interface INotificationService
    {
        BaseViewModel<PagingResult<NotificationViewPage>> getAllNotification(BasePagingRequestViewModel request);
        BaseViewModel<NotificationViewPage> getNotificationById(string id);
        BaseViewModel<NotificationViewPage> create(NotificationCreateViewPage request);
        BaseViewModel<NotificationViewPage> update(NotificationUpdateViewPage request);
        BaseViewModel<NotificationViewPage> readed(string id);
        BaseViewModel<bool> delete(string id);
    }
}
