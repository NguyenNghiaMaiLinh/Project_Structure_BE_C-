using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<Notification> GetAllNotification(int? pageIndex, int? pageSize, string userId, string search);
    }
}
