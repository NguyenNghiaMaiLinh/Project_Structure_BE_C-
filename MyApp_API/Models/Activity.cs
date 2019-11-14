﻿using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class Activity
    {
        public string Id { get; set; }
        public string TaskItemId { get; set; }
        public string ActivityName { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual TaskItem TaskItem { get; set; }
    }
}