using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Notification
    {
        public string Id { get; set; }
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsRead { get; set; }
    }
}
