using System;

namespace MyApp.Core.Data.Entity
{
    public partial class Notification :BaseEntity
    {
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public bool? IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsRead { get; set; }
    }
}
