﻿using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Category
    {
        public Category()
        {
            Workflow = new HashSet<Workflow>();
        }

        public string Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Workflow> Workflow { get; set; }
    }
}