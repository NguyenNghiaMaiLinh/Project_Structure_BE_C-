using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Follower
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Follower1 { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Register AuthorNavigation { get; set; }
        public virtual Register Follower1Navigation { get; set; }
    }
}
