using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class NotificationViewPage
    {
        public string Id { get; set; }
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public string CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsRead { get; set; }
    }
    public partial class NotificationCreateViewPage
    {
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
    }
    public partial class NotificationUpdateViewPage
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
    }
    public partial class NotificationReadViewPage
    {
        public bool? IsRead { get; set; }
    }
    public partial class NotificationDeleteViewPage
    {
        public string Id { get; set; }
    }
}
