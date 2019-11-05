using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Banner
    {
        public string Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? UpdateBy { get; set; }
        public bool? IsDelete { get; set; }
        public string BannerName { get; set; }
        public string UrlImage { get; set; }
    }
}
