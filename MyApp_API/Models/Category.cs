using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Category
    {
        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
        public string CategoryName { get; set; }
    }
}
