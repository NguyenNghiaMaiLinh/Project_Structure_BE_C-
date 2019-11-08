using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDelete { get; set; }
    }
}
