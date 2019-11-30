using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MyApp.Repository.Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        private DataContext _dataContext;
        public NotificationRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Notification> GetAllNotification(int? pageIndex, int? pageSize, string userId, string search)
        {
            if (search == null)
            {
                search = "";
            }
            var par1 = new SqlParameter("@PageIndex", pageIndex);
            var par2 = new SqlParameter("@PageSize", pageSize);
            var par3 = new SqlParameter("@UserId", userId);
            var par4 = new SqlParameter("@Search", search);

            var result = _dataContext.Notification.FromSql("getAllWorkflow @PageIndex, @PageSize, @UserId, @Search", par1, par2, par3, par4).ToList(); ;
            return result;
        }
    }
}
