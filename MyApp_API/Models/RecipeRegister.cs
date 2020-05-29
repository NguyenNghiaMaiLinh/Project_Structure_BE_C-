using System;
using System.Collections.Generic;

namespace MyApp_API.Models
{
    public partial class RecipeRegister
    {
        public string Id { get; set; }
        public string RecipeId { get; set; }
        public string Saver { get; set; }
        public string CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
